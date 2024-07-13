using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.modules.role.repository;

namespace alimenta_bem.data.mappings.role;

public class RoleMap : IEntityTypeConfiguration<Role>
{
       public void Configure(EntityTypeBuilder<Role> builder)
       {
              builder.HasKey(u => u.id);
              builder.Property(u => u.type)
                     .HasColumnType("varchar(100)");
       }
}