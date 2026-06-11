using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteUni.Domain.Restaurants.Menus;

namespace RestauranteUni.Data.EntityBuilders
{
    internal sealed class MenuItemBuilder : BaseEntityBuilder<Guid, MenuItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("menu_items");

            builder.Property(x => x.Title)
                .HasColumnName("title")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            builder.Property(x => x.Price)
                .HasColumnName("price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .HasColumnName("image_url")
                .HasMaxLength(500);

            builder.Property(x => x.IsAvailable)
                .HasColumnName("is_available")
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(x => x.DisplayOrder)
                .HasColumnName("display_order")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.PreparationTimeInMinutes)
                .HasColumnName("preparation_time_in_minutes")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.IsFeatured)
                .HasColumnName("is_featured")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.MenuId)
                .HasColumnName("menu_id")
                .IsRequired();

            builder.HasOne(x => x.Menu)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Menu).AutoInclude();

            // Índices para melhorar performance
            builder.HasIndex(x => x.MenuId);
            builder.HasIndex(x => x.IsAvailable);
            builder.HasIndex(x => x.IsFeatured);
            builder.HasIndex(x => new { x.MenuId, x.DisplayOrder });

            builder.HasData(
                new MenuItem
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Title = "X-Burger",
                    Description = "Hambúrguer artesanal com queijo e salada",
                    Price = 29.90m,
                    ImageUrl = "/images/xburger.jpg",
                    IsAvailable = true,
                    DisplayOrder = 1,
                    PreparationTimeInMinutes = 15,
                    IsFeatured = true,
                    MenuId = MenuBuilder.MenuId,
                    CreatedAt = new DateTime(2026, 1, 1),
                    Active = true
                },
                new MenuItem
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Title = "Pizza Calabresa",
                    Description = "Pizza tradicional de calabresa",
                    Price = 59.90m,
                    ImageUrl = "/images/calabresa.jpg",
                    IsAvailable = true,
                    DisplayOrder = 2,
                    PreparationTimeInMinutes = 25,
                    IsFeatured = true,
                    MenuId = MenuBuilder.MenuId,
                    CreatedAt = new DateTime(2026, 1, 1),
                    Active = true
                },
                new MenuItem
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Title = "Coca-Cola 350ml",
                    Description = "Refrigerante lata",
                    Price = 6.50m,
                    ImageUrl = "/images/coca350.jpg",
                    IsAvailable = true,
                    DisplayOrder = 3,
                    PreparationTimeInMinutes = 1,
                    IsFeatured = false,
                    MenuId = MenuBuilder.MenuId,
                    CreatedAt = new DateTime(2026, 1, 1),
                    Active = true
                }
            );
        }
    }
}
