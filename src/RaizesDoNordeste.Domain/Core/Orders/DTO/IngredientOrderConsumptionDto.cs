using RaizesDoNordeste.Domain.Core.Menus;

namespace RaizesDoNordeste.Domain.Core.Orders.DTO;

public sealed class IngredientOrderConsumptionDto
{
    public MenuItemIngredient Ingredient { get; set; }
    public decimal QuantityToUseInOrder { get; set; }
}
