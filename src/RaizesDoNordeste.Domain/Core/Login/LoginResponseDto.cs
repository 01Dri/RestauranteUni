using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.Domain.Core.Login;

public record LoginResponseDto : IUseCaseResponse
{
    public LoginResponseDto(string token)
    {
        Token = token;
    }

    public string Token { get; set; }
    public Error? ErrorResponse { get; set; }
}
