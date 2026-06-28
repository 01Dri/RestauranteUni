using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Orders;

namespace RaizesDoNordeste.Domain.Core.Stocks;

public class StockIngredientMovement 
{
    public long? Id { get; set; }
    
    public required long  StockIngredientId { get; set; }
    
    public virtual StockIngredient StockIngredient { get; set; } 

    public decimal Quantity { get; set; }

    public StockMovementType Type { get; set; }

    public string? Description { get; set; }

    public required DateTime CreatedAt { get; set; }
    
    public long? OrderId { get; set; }
    public virtual Order? Order { get; set; }
}
