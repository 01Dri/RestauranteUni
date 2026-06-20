using RestauranteUni.Domain.Core.Ingredients.Enums;
using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.Domain.Core.Orders.DTO;

public class OrderResponseDto : IUseCaseResponse
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long AccountId { get; set; }

    public string AccountEmail { get; set; } = string.Empty;

    public decimal TotalPrice { get; set; }

    public OrderStatus Status { get; set; }

    public List<OrderItemResponseDto> Items { get; set; } = [];
}

public class OrderItemResponseDto
{
    public long Id { get; set; }

    public Guid MenuId { get; set; }

    public Guid MenuItemId { get; set; }

    public string MenuItemName { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }
}