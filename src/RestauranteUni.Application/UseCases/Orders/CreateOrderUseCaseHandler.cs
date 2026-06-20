using Microsoft.EntityFrameworkCore;
using RestauranteUni.Data;
using RestauranteUni.Domain.Core.Ingredients.Enums;
using RestauranteUni.Domain.Core.Menus;
using RestauranteUni.Domain.Core.Orders;
using RestauranteUni.Domain.Core.Orders.DTO;
using RestauranteUni.Domain.Core.Stocks;
using RestauranteUni.Domain.Core.Users;
using RestauranteUni.Domain.UseCases;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Application.UseCases.Orders;

public sealed class CreateOrderUseCaseHandler : IUseCaseHandler<CreateOrderDto, OrderResponseDto>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ICurrentUser _currentUser;

    public CreateOrderUseCaseHandler(ApplicationDbContext dbContext, ICurrentUser currentUser)
    {
        _dbContext = dbContext;
        _currentUser = currentUser;
    }

    public async Task<Result<OrderResponseDto>> HandleAsync(CreateOrderDto parameter,
        CancellationToken cancellation = default)
    {

        /**
         * Fluxo criação de pedido
         *
         * 1 - Validar entradas
         * 2 - Validar se items necessários estão disponiveis (Em caso não, informar os items indisponiveis para o pedido)
         * 3 - Verificar se tem ingredientes disponiveis em cada item do menu, quando comporado a quantidade do item no pedido x quantidade do ingrediente no stock
         * 4 - Movimentação de estoque
         * 4 - Criar pedido
         */
        parameter.Items = BuildParameterItems(parameter);
        
        var itemsPublicIds = parameter.Items.Select(x => x.PublicMenuItemId).ToList();
        var menuItems = await _dbContext.MenuItems
            .Include(x => x.Menu)
            .Include(x => x.Ingredients)
            .ThenInclude(x => x.StockIngredient)
            .Where(x => itemsPublicIds.Contains(x.PublicId) && x.Menu.RestaurantId == _currentUser.RestaurantId).ToListAsync(cancellation);
        if (menuItems.Count == 0)
        {
            return Result<OrderResponseDto>.FailureNotFound("Menu items not found");
        }

        var menuItemsNotAvailable = menuItems.Where(x => !x.IsAvailable)
            .Select(x => x.Title).ToList();

        if (menuItemsNotAvailable.Count > 0)
        {
            return ToResponse("Some  menu items is not available.");
        }
        
        var order = new Order()
        {
            Status = OrderStatus.Process,
            Channel = parameter.Channel,
            RestaurantId = _currentUser.RestaurantId,
            AccountId = _currentUser.AccountId
        };

        await _dbContext.AddAsync(order, cancellation);
        await _dbContext.SaveChangesAsync(cancellation);
        
        var menuItemsConsumption = BuildOrderStockConsumption(menuItems, parameter);
        if (menuItemsConsumption == null)
        {
            return ToResponse("Some  menu items is not available.");
        }

        await HandleMenuItemsAsync(menuItemsConsumption, order);
        await _dbContext.SaveChangesAsync(cancellation);

        return Result<OrderResponseDto>.Success(new OrderResponseDto());
    }

    private List<CreateOrderItemDto> BuildParameterItems(CreateOrderDto parameter)
    {
        return parameter.Items
            .GroupBy(x => x.PublicMenuItemId)
            .Select(x => new CreateOrderItemDto()
            {
                PublicMenuItemId = x.Key,
                Quantity = x.Sum(i => i.Quantity)
            }).ToList();
    }


    private List<MenuItemOrderConsumption>? BuildOrderStockConsumption(List<MenuItem> menuItems,
        CreateOrderDto parameter)
    {
        var result = new List<MenuItemOrderConsumption>();

        // Saldo temporário para simular consumo
        var availableStock = menuItems
            .SelectMany(x => x.Ingredients)
            .Select(x => x.StockIngredient)
            .DistinctBy(x => x.Id)
            .ToDictionary(
                x => x.Id,
                x => x.Quantity);

        foreach (var orderItem in parameter.Items)
        {
            var menuItem = menuItems.FirstOrDefault(x => x.PublicId == orderItem.PublicMenuItemId);

            if (menuItem is null)
            {
                return null;
            }

            var ingredientConsumption = new MenuItemOrderConsumption()
            {
                Item = menuItem
            };

            foreach (var ingredient in menuItem.Ingredients)
            {
                var stockIngredient = ingredient.StockIngredient;

                var quantityToConsume =
                    ingredient.QuantityUseToOrder * orderItem.Quantity;

                var currentStock =
                    availableStock[stockIngredient.Id];

                if (quantityToConsume > currentStock)
                {
                    return null;
                }

                availableStock[stockIngredient.Id] -= quantityToConsume;

                ingredientConsumption.IngredientConsumptions.Add(
                    new IngredientOrderConsumption()
                    {
                        Ingredient = ingredient,
                        QuantityToUseInOrder = quantityToConsume
                    });
            }

            result.Add(ingredientConsumption);
        }

        return result;
    }


    private async Task HandleMenuItemsAsync(List<MenuItemOrderConsumption> menuItems, Order order)
    {
        foreach (var menuItem in menuItems)
        {
            foreach (var ingredientPreOrder in menuItem.IngredientConsumptions)
            {
                var stockIngredient =
                    ingredientPreOrder.Ingredient.StockIngredient;

                stockIngredient.Quantity -=
                    ingredientPreOrder.QuantityToUseInOrder;

                await _dbContext.StockIngredientMovements.AddAsync(
                    new StockIngredientMovement
                    {
                        StockIngredientId = stockIngredient.Id,
                        Type = StockMovementType.Consumption,
                        Quantity = ingredientPreOrder.QuantityToUseInOrder,
                        Description = "Consumption in an order",
                        CreatedAt = DateTime.UtcNow,
                        Order = order
                    });
                
            }

            menuItem.Item.IsAvailable =
                menuItem.Item.Ingredients.All(x =>
                    x.StockIngredient.Quantity >= x.QuantityUseToOrder);

            _dbContext.MenuItems.Update(menuItem.Item);
            order.Items.Add(new OrderItem()
            {
                MenuItem = menuItem.Item,
            });

            _dbContext.Orders.Update(order);
        }
        
    }
    
    private Result<OrderResponseDto> ToResponse(string message, string? error = null)
    {
        Validation validation = null;

        if (!string.IsNullOrEmpty(error))
        {
            validation = new Validation(message, error);
        }
        else
        {
            validation = new Validation(message);
        }
        return Result<OrderResponseDto>.Failure(new[]
        {
            validation
        });
    }
}

class MenuItemOrderConsumption
{
    public MenuItem Item { get; set; }
    public List<IngredientOrderConsumption> IngredientConsumptions { get; set; } = [];
}


class IngredientOrderConsumption
{
    public MenuItemIngredient Ingredient { get; set; }
    public decimal QuantityToUseInOrder { get; set; }
    
} 
