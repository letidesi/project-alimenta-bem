using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.data.mappings.natural.person;

public class NaturalPersonMap : IEntityTypeConfiguration<NaturalPerson>
{
       public void Configure(EntityTypeBuilder<NaturalPerson> builder)
       {
              builder.HasOne(n => n.user)
                     .WithMany(u => u.naturalPersons)
                     .HasForeignKey(n => n.userId)
                     .IsRequired()
                     .OnDelete(DeleteBehavior.Cascade);
              builder.HasKey(n => n.id);
              builder.Property(n => n.name)
                     .HasColumnType("varchar(max)");
              builder.Property(n => n.socialName)
                     .HasColumnType("varchar(100)")
                     .IsRequired(false);
              builder.Property(n => n.emailUser)
                     .HasColumnType("varchar(200)")
                     .IsRequired();
              builder.Property(n => n.age)
                     .HasColumnType("varchar(50)");
              builder.Property(n => n.birthdayDate)
                     .HasConversion<DateOnlyConverter, DateOnlyComparer>();
              builder.Property(n => n.gender)
                     .HasColumnType("varchar(100)")
                     .HasConversion<string>()
                     .IsRequired(false);
              builder.Property(n => n.skinColor)
                     .HasColumnType("varchar(100)")
                     .HasConversion<string>()
                     .IsRequired(false);
              builder.Property(n => n.isPcd)
                     .HasColumnType("varchar(100)")
                     .HasConversion<string>()
                     .IsRequired(false);
       }
}