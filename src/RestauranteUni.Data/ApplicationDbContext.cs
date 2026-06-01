using Microsoft.EntityFrameworkCore;
using RestauranteUni.Domain.Accounts;
using RestauranteUni.Domain.Accounts.Roles;

namespace RestauranteUni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
