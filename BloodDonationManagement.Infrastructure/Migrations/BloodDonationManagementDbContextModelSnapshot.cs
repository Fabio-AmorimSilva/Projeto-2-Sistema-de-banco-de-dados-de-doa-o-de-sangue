﻿// <auto-generated />
using System;
using BloodDonationManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodDonationManagement.Infrastructure.Migrations
{
    [DbContext(typeof(BloodDonationManagementDbContext))]
    partial class BloodDonationManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.BloodStock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RhFactor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BloodStocks", (string)null);
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DonatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonatorId");

                    b.ToTable("Donations", (string)null);
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.Donator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<int>("BloodType")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RhFactor")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Donators", (string)null);
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.Donation", b =>
                {
                    b.HasOne("BloodDonationManagement.Domain.Entities.Donator", "Donator")
                        .WithMany("Donations")
                        .HasForeignKey("DonatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donator");
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.Donator", b =>
                {
                    b.OwnsOne("BloodDonationManagement.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("DonatorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Cep")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier")
                                .HasDefaultValueSql("NEWID()");

                            b1.Property<string>("PublicArea")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DonatorId");

                            b1.ToTable("Donators");

                            b1.WithOwner()
                                .HasForeignKey("DonatorId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("BloodDonationManagement.Domain.Entities.Donator", b =>
                {
                    b.Navigation("Donations");
                });
#pragma warning restore 612, 618
        }
    }
}