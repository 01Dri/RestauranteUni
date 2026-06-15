using RestauranteUni.Domain.Ingredients.Enums;
using RestauranteUni.Domain.Menus;

namespace RestauranteUni.Domain.Stocks
{
    public class StockIngredient : BaseDomain<long>
    {

        public Guid PublicId { get; set; }
        public required string Name { get; set; }

        public required IngredientUnit Unit { get; set; }

        public decimal Quantity { get; set; }

        public long? StockId { get; set; }
        public Stock Stock { get; set; } = null!;
        
        public virtual ICollection<MenuItemIngredient> MenuItemIngredients { get; set; } = [];
    }
    
}
