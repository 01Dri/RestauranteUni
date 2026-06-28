using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Accounts.Roles;
using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Orders;
using RaizesDoNordeste.Domain.Core.Users;
using RaizesDoNordeste.Domain.UseCases;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Patterns.Dispatchers.Orders.Handlers;

public sealed class OrderStatusCancelledHandler : IOrderStatusHandler
{
    public OrderStatus Status { get; } = OrderStatus.Cancelled;
    public async Task<Result> HandleAsync(Order order, ICurrentUser user, ApplicationDbContext context)
    {
        var statusAllowedToCancel = new List<OrderStatus>()
        {
            OrderStatus.Process,
            OrderStatus.Chicken,
            OrderStatus.Ready
        };

        if (!user.InRole(RoleType.Customer))
        {
            return Result.Failure(new Error("Usuário não possui permissão"));
        }
        
        if (order.Status == Status)
        {
            return Result.Success();
        }

        if (order.Status == OrderStatus.Delivered)
        {
            return Result.Failure(new Error()
            {
                Message = "O produto já foi entregue ao cliente"
            });
        }

        if (!statusAllowedToCancel.Contains(order.Status))
        {
            return Result.Failure(new Error()
            {
                Message = "Não é possivel cancelar este pedido."
            });
        }


        if (order.Status == OrderStatus.Chicken)
        {
            await context.StockIngredientMovements
                .Where(x => x.OrderId == order.Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(x => x.Type, StockMovementType.Loss)
                    .SetProperty(x => x.Description, "Pedido cancelado"));
        }

        order.Status = Status;
        return Result.Success();
    }
}
