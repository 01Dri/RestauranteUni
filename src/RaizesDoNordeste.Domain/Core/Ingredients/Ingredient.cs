using RaizesDoNordeste.Domain.Core.Ingredients.Enums;

namespace RaizesDoNordeste.Domain.Core.Ingredients;

public class Ingredient : BaseDomain<long>
{
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required IngredientUnit Unit { get; set; }
}
