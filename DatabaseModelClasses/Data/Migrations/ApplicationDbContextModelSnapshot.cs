﻿// <auto-generated />
using System;
using DatabaseModelClasses.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseModelClasses.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("DatabaseModelClasses.Manifest", b =>
                {
                    b.Property<int>("ManifestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ManifestId");

                    b.HasIndex("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Manifests");

                    b.HasData(
                        new
                        {
                            ManifestId = 1,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6442),
                            CreatedBy = "Admin",
                            Id = 1,
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6483),
                            ModifiedBy = "Admin",
                            Notes = "John's trip.",
                            TripId = 1
                        },
                        new
                        {
                            ManifestId = 2,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6490),
                            CreatedBy = "Admin",
                            Id = 2,
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6494),
                            ModifiedBy = "Admin",
                            Notes = "Jane's trip.",
                            TripId = 2
                        },
                        new
                        {
                            ManifestId = 3,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6500),
                            CreatedBy = "Admin",
                            Id = 3,
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6503),
                            ModifiedBy = "Admin",
                            Notes = "Jim's trip.",
                            TripId = 3
                        });
                });

            modelBuilder.Entity("DatabaseModelClasses.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("MemberId");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("Members", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            City = "Springfield",
                            ConcurrencyStamp = "4e25e28d-14b3-4e88-9422-69347e8a95f0",
                            Country = "USA",
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3806),
                            CreatedBy = "Admin",
                            Email = "a@a.a",
                            EmailConfirmed = true,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            Mobile = "555-0100",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3809),
                            ModifiedBy = "Admin",
                            NormalizedEmail = "A@A.A",
                            NormalizedUserName = "A@A.A",
                            PasswordHash = "AQAAAAIAAYagAAAAEFe6SkMhBUxbdXC1DPGLqG8wpbXpt5FtHfvrTorVrar/v5+CPmgahMMR19Gfc9+lMg==",
                            PhoneNumberConfirmed = false,
                            PostalCode = "12345",
                            SecurityStamp = "fd95997a-7d5b-42dd-8b6c-1f9e71152d43",
                            Street = "123 Elm St",
                            TwoFactorEnabled = false,
                            UserName = "a@a.a"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            City = "Metropolis",
                            ConcurrencyStamp = "7732f772-c4a3-4888-aab7-57e8c9082f85",
                            Country = "USA",
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 606, DateTimeKind.Local).AddTicks(2973),
                            CreatedBy = "Admin",
                            Email = "o@o.o",
                            EmailConfirmed = true,
                            FirstName = "Jane",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            Mobile = "555-0200",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 606, DateTimeKind.Local).AddTicks(3051),
                            ModifiedBy = "Admin",
                            NormalizedEmail = "O@O.O",
                            NormalizedUserName = "O@O.O",
                            PasswordHash = "AQAAAAIAAYagAAAAEHOmz1YjfOo0xdSE0KSVX70K366Fz/zkuYsLnxqj/gWW06ga+zfjSeJSKA8TA37/Dg==",
                            PhoneNumberConfirmed = false,
                            PostalCode = "67890",
                            SecurityStamp = "c0750046-91de-4b1d-89c9-906385bff45c",
                            Street = "456 Oak St",
                            TwoFactorEnabled = false,
                            UserName = "o@o.o"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            City = "Gotham",
                            ConcurrencyStamp = "5935233e-51d7-48af-97fc-230c213d139e",
                            Country = "USA",
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 711, DateTimeKind.Local).AddTicks(9874),
                            CreatedBy = "Admin",
                            Email = "p@p.p",
                            EmailConfirmed = true,
                            FirstName = "Jim",
                            LastName = "Bean",
                            LockoutEnabled = false,
                            Mobile = "555-0300",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 711, DateTimeKind.Local).AddTicks(9973),
                            ModifiedBy = "Admin",
                            NormalizedEmail = "P@P.P",
                            NormalizedUserName = "P@P.P",
                            PasswordHash = "AQAAAAIAAYagAAAAEMm3yF4KFgvpn7oHd32JX1+ctVfJupsLSQHPZIpcm34HLD0HaMqZJIXkFh9VYKL2iA==",
                            PhoneNumberConfirmed = false,
                            PostalCode = "10112",
                            SecurityStamp = "89808779-bd43-4a29-a3de-a12aba570c20",
                            Street = "789 Pine St",
                            TwoFactorEnabled = false,
                            UserName = "p@p.p"
                        });
                });

            modelBuilder.Entity("DatabaseModelClasses.Models.CustomRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("CustomRole", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3621),
                            Description = "Administrator Role",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3682),
                            Description = "Owner Role",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 2, 14, 17, 27, 15, 520, DateTimeKind.Local).AddTicks(3689),
                            Description = "Passenger Role",
                            Name = "Passenger",
                            NormalizedName = "PASSENGER"
                        });
                });

            modelBuilder.Entity("DatabaseModelClasses.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("MeetingAddress")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("Time");

                    b.Property<int>("VehicleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TripId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            TripId = 1,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6312),
                            CreatedBy = "Admin",
                            Date = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DestinationAddress = "100 Main St, Springfield",
                            MeetingAddress = "150 Main St, Springfield",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6322),
                            ModifiedBy = "Admin",
                            Time = new DateTime(1, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 1
                        },
                        new
                        {
                            TripId = 2,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6340),
                            CreatedBy = "Admin",
                            Date = new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DestinationAddress = "200 Main St, Metropolis",
                            MeetingAddress = "250 Main St, Metropolis",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6344),
                            ModifiedBy = "Admin",
                            Time = new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 2
                        },
                        new
                        {
                            TripId = 3,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6350),
                            CreatedBy = "Admin",
                            Date = new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DestinationAddress = "300 Main St, Gotham",
                            MeetingAddress = "350 Main St, Gotham",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(6353),
                            ModifiedBy = "Admin",
                            Time = new DateTime(1, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 3
                        });
                });

            modelBuilder.Entity("DatabaseModelClasses.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("VehicleId");

                    b.HasIndex("Id");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5401),
                            CreatedBy = "Admin",
                            Id = 1,
                            Make = "Generic",
                            Model = "Sedan",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5499),
                            ModifiedBy = "Admin",
                            NumberOfSeats = 4,
                            VehicleType = "Economy",
                            Year = 2020
                        },
                        new
                        {
                            VehicleId = 2,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5509),
                            CreatedBy = "Admin",
                            Id = 2,
                            Make = "FastCars",
                            Model = "Coupe",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5513),
                            ModifiedBy = "Admin",
                            NumberOfSeats = 2,
                            VehicleType = "Sport",
                            Year = 2019
                        },
                        new
                        {
                            VehicleId = 3,
                            Created = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5601),
                            CreatedBy = "Admin",
                            Id = 3,
                            Make = "BigCars",
                            Model = "SUV",
                            Modified = new DateTime(2024, 2, 14, 17, 27, 15, 822, DateTimeKind.Local).AddTicks(5605),
                            ModifiedBy = "Admin",
                            NumberOfSeats = 6,
                            VehicleType = "Luxury",
                            Year = 2021
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DatabaseModelClasses.Manifest", b =>
                {
                    b.HasOne("DatabaseModelClasses.Member", "Member")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseModelClasses.Trip", "Trip")
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("DatabaseModelClasses.Trip", b =>
                {
                    b.HasOne("DatabaseModelClasses.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("DatabaseModelClasses.Vehicle", b =>
                {
                    b.HasOne("DatabaseModelClasses.Member", "Member")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("DatabaseModelClasses.Models.CustomRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DatabaseModelClasses.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DatabaseModelClasses.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("DatabaseModelClasses.Models.CustomRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseModelClasses.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DatabaseModelClasses.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
