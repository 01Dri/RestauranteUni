namespace RestauranteUni.Domain.Restaurants.Menus
{
    public class Menu : BaseDomain<Guid>
    {
        public required string Name { get; set; }
        public virtual List<MenuItem> Items { get; set; } = [];

        public Guid? RestaurantId { get; set; }
        public Restaurant? Restaurant{ get; set; }

    }
}
