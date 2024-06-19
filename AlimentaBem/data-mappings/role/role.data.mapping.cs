using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta.bem.role.repository;

namespace alimenta.bem.data.mappings.role;

public class RoleMap : IEntityTypeConfiguration<Role>
{
       public void Configure(EntityTypeBuilder<Role> builder)
       {
              builder.HasKey(u => u.Id);
              builder.Property(u => u.Type)
                     .HasColumnType("varchar(100)");
       }
}