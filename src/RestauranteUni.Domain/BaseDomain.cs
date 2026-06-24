namespace RestauranteUni.Domain
{
    public class BaseDomain<TID>
    {
        public TID? Id { get; set; }
        public DateTime CreatedAt { get; set; } = Calendar.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; } = true;
    }
}
