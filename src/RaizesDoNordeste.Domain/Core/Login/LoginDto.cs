using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.Domain.Core.Login;

public record LoginDto(string Email, string Password, Guid RestaurantId) : IUseCaseRequest;
