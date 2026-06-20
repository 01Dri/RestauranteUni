using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteUni.Domain.Core.Stocks;

namespace RestauranteUni.Data.EntityBuilders;

public class StockIngredientMovementBuilder : IEntityTypeConfiguration<StockIngredientMovement>
{
    public void Configure(EntityTypeBuilder<StockIngredientMovement> builder)
    {
        builder.ToTable("stock_ingredient_movement");

        builder.Property(x => x.Id)
            .HasColumnName("id");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StockIngredientId)
            .HasColumnName("stock_ingredient_id").IsRequired();

        builder.HasOne(x => x.StockIngredient)
            .WithMany(s => s.StockMovements)
            .HasForeignKey(x => x.StockIngredientId);


        builder.Property(x => x.OrderId)
            .HasColumnName("order_id");
        
        builder.HasOne(x => x.Order)
            .WithMany(x => x.StockIngredientMovements)
            .HasForeignKey(X => X.OrderId);
        
        builder.Property(x => x.Quantity).HasColumnName("quantity");
        builder.Property(x => x.Type).HasColumnName("type");
        builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(255);
        builder.Property(x => x.CreatedAt).HasColumnName("created_at")
            .IsRequired();


        builder.Navigation(x => x.StockIngredient);


    }
}