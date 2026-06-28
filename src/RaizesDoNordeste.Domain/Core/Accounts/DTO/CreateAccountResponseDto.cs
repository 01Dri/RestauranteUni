using RaizesDoNordeste.Domain.Core.Accounts.Roles;
using RaizesDoNordeste.Domain.UseCases;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Domain.Core.Accounts.DTO;

public class CreateAccountUseCaseResponseDto
    : IUseCaseResponse<long>
{
    public Email Email { get; set; } = null!;
    public List<RoleType> Roles { get; set; } = [];
    public long Id { get; set; }
    public Error? ErrorResponse { get; set; }
}
