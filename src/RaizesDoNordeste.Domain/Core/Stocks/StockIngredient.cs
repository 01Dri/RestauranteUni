using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Menus;

namespace RaizesDoNordeste.Domain.Core.Stocks;

public class StockIngredient : BaseDomain<long>
{
    public Guid PublicId { get; set; }
    public required string Name { get; set; }

    public required IngredientUnit Unit { get; set; }

    public decimal Quantity { get; set; }

    public long? StockId { get; set; }
    public Stock Stock { get; set; } = null!;
    public virtual ICollection<MenuItemIngredient> MenuItemIngredients { get; set; } = [];
    public virtual ICollection<StockIngredientMovement> StockMovements { get; set; } = [];
}
