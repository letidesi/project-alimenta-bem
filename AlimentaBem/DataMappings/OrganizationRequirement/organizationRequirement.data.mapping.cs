using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.organization.repository;
using alimenta_bem.src.organization.requirement.repository;

namespace alimenta_bem.data.mappings.organization.requirement;

public class NaturalPersonMap : IEntityTypeConfiguration<OrganizationRequirement>
{
       public void Configure(EntityTypeBuilder<OrganizationRequirement> builder)
       {
              builder.HasOne(or => or.organization)
                     .WithMany(o => o.OrganizationRequirements)
                     .HasForeignKey(or => or.id);
              builder.HasKey(or => or.id);
              builder.Property(or => or.itemName)
                     .HasColumnType("varchar(150)");
              builder.Property(or => or.quantity);
              builder.Property(or => or.type)
                     .HasColumnType("varchar(40)")
                     .HasConversion<string>()
;
       }
}