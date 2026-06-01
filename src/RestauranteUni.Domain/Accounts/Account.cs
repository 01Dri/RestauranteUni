using RestauranteUni.Domain.Accounts.Roles;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.Domain.Accounts
{
    public class Account : BaseDomain<long>
    {
        public Email Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual List<RoleAccount> RoleAccounts { get; set; } = [];

    }
}
