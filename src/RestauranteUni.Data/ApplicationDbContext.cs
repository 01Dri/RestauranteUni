using Microsoft.EntityFrameworkCore;
using RestauranteUni.Domain.Accounts;
using RestauranteUni.Domain.Accounts.Roles;
using RestauranteUni.Domain.Ingredients;
using RestauranteUni.Domain.Menus;
using RestauranteUni.Domain.Restaurants;
using RestauranteUni.Domain.Stocks;

namespace RestauranteUni.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MenuItemIngredient> MenuItemIngredients { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<StockIngredient> StockIngredients { get; set; }

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
