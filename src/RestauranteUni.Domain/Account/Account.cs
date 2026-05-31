using RestauranteUni.Domain.Account.Roles;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Domain.Account
{
    public class Account : BaseDomain<long>
    {
        public Email Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual List<RoleAccount> RoleAccounts { get; set; } = [];

    }
}
