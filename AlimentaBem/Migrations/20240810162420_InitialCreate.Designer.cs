﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using alimenta_bem.db.context;

#nullable disable

namespace alimenta_bem.Migrations
{
    [DbContext(typeof(AlimentaBemContext))]
    [Migration("20240810162420_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("alimenta_bem.src.donation.repository.Donation", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("amountDonated")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("naturalPersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("organizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("id");

                    b.HasIndex("naturalPersonId");

                    b.HasIndex("organizationId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("alimenta_bem.src.modules.role.repository.Role", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("alimenta_bem.src.modules.user.repository.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("alimenta_bem.src.natural.person.repository.NaturalPerson", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("birthdayDate")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("gender")
                        .HasColumnType("int");

                    b.Property<bool?>("isPcd")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("skinColor")
                        .HasColumnType("int");

                    b.Property<string>("socialName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("userId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("NaturalPersons");
                });

            modelBuilder.Entity("alimenta_bem.src.organization.repository.Organization", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("type")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("alimenta_bem.src.organization.requirement.repository.OrganizationRequirement", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("createdAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("deletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("itemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("organizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("updatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("id");

                    b.HasIndex("organizationId");

                    b.ToTable("OrganizationRequirements");
                });

            modelBuilder.Entity("alimenta_bem.src.donation.repository.Donation", b =>
                {
                    b.HasOne("alimenta_bem.src.natural.person.repository.NaturalPerson", "naturalPerson")
                        .WithMany("donations")
                        .HasForeignKey("naturalPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("alimenta_bem.src.organization.repository.Organization", "organization")
                        .WithMany("donations")
                        .HasForeignKey("organizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("naturalPerson");

                    b.Navigation("organization");
                });

            modelBuilder.Entity("alimenta_bem.src.modules.role.repository.Role", b =>
                {
                    b.HasOne("alimenta_bem.src.modules.user.repository.User", "user")
                        .WithMany("roles")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("alimenta_bem.src.natural.person.repository.NaturalPerson", b =>
                {
                    b.HasOne("alimenta_bem.src.modules.user.repository.User", "user")
                        .WithMany("naturalPersons")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("alimenta_bem.src.organization.requirement.repository.OrganizationRequirement", b =>
                {
                    b.HasOne("alimenta_bem.src.organization.repository.Organization", "organization")
                        .WithMany("OrganizationRequirements")
                        .HasForeignKey("organizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("organization");
                });

            modelBuilder.Entity("alimenta_bem.src.modules.user.repository.User", b =>
                {
                    b.Navigation("naturalPersons");

                    b.Navigation("roles");
                });

            modelBuilder.Entity("alimenta_bem.src.natural.person.repository.NaturalPerson", b =>
                {
                    b.Navigation("donations");
                });

            modelBuilder.Entity("alimenta_bem.src.organization.repository.Organization", b =>
                {
                    b.Navigation("OrganizationRequirements");

                    b.Navigation("donations");
                });
#pragma warning restore 612, 618
        }
    }
}
