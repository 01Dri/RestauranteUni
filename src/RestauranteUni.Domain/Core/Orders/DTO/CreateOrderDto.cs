using RestauranteUni.Domain.Core.Ingredients.Enums;
using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.Domain.Core.Orders.DTO;

public class CreateOrderDto : IUseCaseRequest
{
    public OrderChannel Channel { get; set; }

    public List<CreateOrderItemDto> Items { get; set; } = [];
}

public class CreateOrderItemDto
{
    public Guid PublicMenuItemId { get; set; }

    public decimal Quantity { get; set; }
}