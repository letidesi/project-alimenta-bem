using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.modules.user.repository;

namespace alimenta_bem.data.mappings.user;

public class UserMap : IEntityTypeConfiguration<User>
{
       public void Configure(EntityTypeBuilder<User> builder)
       {
              builder.HasMany(u => u.Roles)
                     .WithOne(r => r.User)
                     .HasForeignKey(r => r.UserId);
              builder.HasKey(u => u.Id);
              builder.Property(u => u.Name)
                     .HasColumnType("varchar(100)");
              builder.Property(u => u.Email)
                    .HasColumnType("varchar(100)");
              builder.Property(u => u.Name)
                     .HasColumnType("varchar(100)");
              builder.Property(u => u.PasswordHash)
                     .HasColumnType("varchar(max)");
       }
}