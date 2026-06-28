using RaizesDoNordeste.Domain.Core.Restaurants;

namespace RaizesDoNordeste.Domain.Core.Stocks;

public class Stock : BaseDomain<long>
{
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public Guid? RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public virtual ICollection<StockIngredient> Items { get; set; } = [];
}
