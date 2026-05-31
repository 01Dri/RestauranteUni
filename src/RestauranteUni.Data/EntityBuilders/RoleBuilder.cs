using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteUni.Domain.Account.Roles;

namespace RestauranteUni.Data.EntityBuilders
{
    internal sealed class RoleBuilder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Type)
                .HasColumnName("type")
                .IsRequired();

            builder.Ignore(x => x.Name);

            builder.HasIndex(x => x.Type)
                .HasDatabaseName("ix_roles_type")
                .IsUnique();

            builder.HasData(
                new Role { Id = 1, Type = RoleType.Customer },
                new Role { Id = 2, Type = RoleType.Manager },
                new Role { Id = 3, Type = RoleType.Admin },
                new Role { Id = 4, Type = RoleType.Professional },
                new Role { Id = 5, Type = RoleType.Owner });
        }
    }
}
