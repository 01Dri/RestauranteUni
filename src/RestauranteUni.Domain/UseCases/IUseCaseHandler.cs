    namespace RestauranteUni.Domain.UseCases;

    public interface IUseCaseHandler<TParameter, TResponse>
        where TParameter : IRequest
        where TResponse : IResponse
    {
        Task<Result<TResponse>> HandleAsync(TParameter parameter, CancellationToken cancellation = default);
    }

    public interface IRequest;
    public interface IResponse;


