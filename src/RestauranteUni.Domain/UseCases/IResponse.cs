namespace RestauranteUni.Domain.UseCases
{
    public interface IResponse<TId> : IResponse
    {
        public TId Id { get; set; }
    }
}
