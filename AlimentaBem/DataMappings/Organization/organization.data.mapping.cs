using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.organization.repository;

namespace alimenta_bem.data.mappings.organization;

public class NaturalPersonMap : IEntityTypeConfiguration<Organization>
{
       public void Configure(EntityTypeBuilder<Organization> builder)
       {
              builder.HasKey(o => o.id);
              builder.Property(o => o.name)
                     .HasColumnType("varchar(150)");
              builder.Property(o => o.type)
                     .HasColumnType("varchar(40)")
                     .HasConversion<string>();
              builder.Property(o => o.description)
                     .HasColumnType("varchar(500)");
       }
}