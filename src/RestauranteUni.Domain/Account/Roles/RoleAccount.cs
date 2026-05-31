namespace RestauranteUni.Domain.Account.Roles
{
    public class RoleAccount
    {
        public long? Id { get; set; }

        public long? AccountId { get; set; }
        public virtual Account? Account { get; set; } = null!;

        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; } = null!;
        public required RoleStatus RoleStatus { get; set; }
    }
}
