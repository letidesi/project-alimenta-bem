using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.data.mappings.user;

public class UserMap : IEntityTypeConfiguration<User>
{
       public void Configure(EntityTypeBuilder<User> builder)
       {
              builder.HasMany(u => u.roles)
                     .WithOne(r => r.user)
                     .HasForeignKey(r => r.userId);
              builder.HasKey(u => u.id);
              builder.Property(u => u.name)
                     .HasColumnType("varchar(100)");
              builder.Property(u => u.email)
                    .HasColumnType("varchar(100)");
              builder.Property(u => u.name)
                     .HasColumnType("varchar(100)");
              builder.Property(u => u.passwordHash)
                     .HasColumnType("varchar(max)");
       }
}