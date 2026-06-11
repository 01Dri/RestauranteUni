namespace RestauranteUni.Domain.Restaurants.Menus
{
    public class MenuItem : BaseDomain<Guid>
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsAvailable { get; set; } = true;

        public int DisplayOrder { get; set; }

        public int PreparationTimeInMinutes { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? MenuId { get; set; }
        public virtual Menu? Menu { get; set; }

    }
}
