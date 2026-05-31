using RestauranteUni.Domain.Account.Roles;
using RestauranteUni.Domain.UseCases;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Domain.Account.DTO
{
    public class CreateAccountResponseDto 
        : IResponse<long>
    {
        public long Id { get; set; }
        public Email Email { get; set; } = null!;
        public List<RoleType> Roles { get; set; } = [];
    }
}
