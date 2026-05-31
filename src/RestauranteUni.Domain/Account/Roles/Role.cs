namespace RestauranteUni.Domain.Account.Roles
{
    public sealed class Role : IEquatable<Role>
    {
        public int? Id { get; set; }

        public RoleType Type { get; set; }

        public string Name => Type.ToString();

        public List<RoleAccount> RoleAccounts { get; set; } = [];

        public bool Equals(Role? other)
        {
            return other is not null && Type == other.Type;
        }

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                Role role => Equals(role),
                RoleType roleType => Type == roleType,
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        public static bool operator ==(Role? role, RoleType roleType)
        {
            return role?.Type == roleType;
        }

        public static bool operator !=(Role? role, RoleType roleType)
        {
            return !(role == roleType);
        }
        public static implicit operator Role(RoleType roleType)
        {
            return new Role
            {
                Type = roleType
            };
        }

    }
}
