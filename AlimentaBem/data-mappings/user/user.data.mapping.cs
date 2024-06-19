using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta.bem.user.repository;

namespace alimenta.bem.data.mappings.user;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
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