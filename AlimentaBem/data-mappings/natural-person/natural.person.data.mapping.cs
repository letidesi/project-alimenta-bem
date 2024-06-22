using Microsoft.EntityFrameworkCore.Metadata.Builders;
using alimenta_bem.src.natural.person.repository;

namespace alimenta_bem.data.mappings.natural.person;

public class NaturalPersonMap : IEntityTypeConfiguration<NaturalPerson>
{
       public void Configure(EntityTypeBuilder<NaturalPerson> builder)
       {
              builder.HasOne(n => n.User)
                     .WithMany(u => u.NaturalPersons)
                     .HasForeignKey(n => n.UserId);
              builder.HasKey(n => n.Id);
              builder.Property(n => n.FirstName)
                     .HasColumnType("varchar(100)");
              builder.Property(n => n.LastName)
                    .HasColumnType("varchar(100)");
              builder.Property(n => n.SocialName)
                     .HasColumnType("varchar(100)")
                     .IsRequired(false);
              builder.Property(n => n.Cpf)
                     .HasColumnType("varchar(100)");
              builder.Property(n => n.Rg)
                     .HasColumnType("varchar(100)");
              builder.Property(n => n.Age)
                     .HasColumnType("varchar(50)");
              builder.Property(n => n.BirthdayDate)
                     .HasConversion<DateOnlyConverter, DateOnlyComparer>();
              builder.Property(n => n.Gender)
                     .HasColumnType("varchar(100)")
                     .IsRequired(false);
              builder.Property(n => n.SkinColor)
                     .HasColumnType("varchar(100)")
                     .IsRequired(false);
              builder.Property(n => n.IsPcd)
                     .HasColumnType("varchar(100)")
                     .IsRequired(false);
       }
}