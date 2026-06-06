using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteUni.Domain;

namespace RestauranteUni.Data.EntityBuilders;

public abstract class BaseEntityBuilder<TId, TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseDomain<TId>
{
    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);

    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureBase(builder);
        ConfigureEntity(builder);
    }

    private static void ConfigureBase(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("updated_at");

        builder.Property(x => x.Active)
            .HasColumnName("active")
            .HasDefaultValue(true)
            .IsRequired();

        builder
            .HasQueryFilter("OnlyActive", x => x.Active);
    }
}
