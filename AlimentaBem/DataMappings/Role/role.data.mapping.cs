using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.modules.role.repository;

namespace alimenta_bem.data.mappings.role;

public class RoleMap : IEntityTypeConfiguration<Role>
{
       public void Configure(EntityTypeBuilder<Role> builder)
       {
              builder.HasOne(r => r.user)
                     .WithMany(r => r.roles)
                     .HasForeignKey(r => r.userId);
              builder.HasKey(r => r.id);
              builder.Property(r => r.type)
                     .HasColumnType("varchar(100)")
                     .IsRequired(true);
       }
}