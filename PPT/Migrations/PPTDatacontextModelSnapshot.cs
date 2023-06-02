﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPT.Data;

#nullable disable

namespace PPT.Migrations
{
    [DbContext(typeof(PPTDatacontext))]
    partial class PPTDatacontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "64c0bac3-9025-42a6-9f3c-744e361b4cf7",
                            ConcurrencyStamp = "57ab0584-18bd-42b8-9db5-cd1674deb634",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "b467e238-5fcc-49ce-b85c-0d5a40f30ae6",
                            ConcurrencyStamp = "8519a517-729c-43d3-9367-36c15a120fa8",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96",
                            ConcurrencyStamp = "82e6b33c-1a40-4285-9346-cba810d11a31",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            RoleId = "64c0bac3-9025-42a6-9f3c-744e361b4cf7"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            RoleId = "b467e238-5fcc-49ce-b85c-0d5a40f30ae6"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            RoleId = "6eae0a44-7fd5-41d8-8ffb-b0ebb77eeb96"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PPT.Models.Attendance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 3,
                            Duration = 0,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 1,
                            Duration = 0,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 1,
                            Duration = 0,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 4,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 2,
                            Duration = 0,
                            IsPublished = false
                        });
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretaryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SectionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SecretaryID");

                    b.HasIndex("SectionID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Computer science and mathmatics",
                            SecretaryID = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            SectionID = 2
                        },
                        new
                        {
                            ID = 2,
                            Name = "Physics",
                            SectionID = 1
                        },
                        new
                        {
                            ID = 3,
                            Name = "Chemistry",
                            SectionID = 1
                        },
                        new
                        {
                            ID = 4,
                            Name = "Biochemistry",
                            SectionID = 2
                        });
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfficeLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Rank")
                        .HasColumnType("bit");

                    b.Property<string>("UniversityId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DepartmentID = 1,
                            Name = "علي غريب",
                            Rank = false
                        },
                        new
                        {
                            ID = 2,
                            DepartmentID = 1,
                            Name = "محمد دبوق",
                            Rank = false
                        },
                        new
                        {
                            ID = 3,
                            DepartmentID = 1,
                            Name = "كمال بيضون",
                            Rank = false
                        },
                        new
                        {
                            ID = 4,
                            DepartmentID = 1,
                            Name = "أحمد فاعور",
                            Rank = false
                        });
                });

            modelBuilder.Entity("PPT.Models.Faculty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Faculties");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Faculty of Sciences"
                        });
                });

            modelBuilder.Entity("PPT.Models.Section", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Zahle"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Hadath"
                        });
                });

            modelBuilder.Entity("PPT.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7d8e85ee-c32c-41c5-ab4a-eaf2a981bf44",
                            Email = "adam.bazzal666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADAM.BAZZAL666@GMAIL.com",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEP0q8UK4cejvJZK6exiup5FdZYwkXVdRiebSmaaHnRKhjn0KzRIZaL+zLZNok5WkKA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bb5c950f-0ec9-46f0-93a5-1ecc4b87657d",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            FirstName = "Adam",
                            LastName = "Bazzal"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f0bba5f3-d797-451c-aa37-bd59a71340f9",
                            Email = "samar.bazzal666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "SAMAR.BAZZAL666@GMAIL.com",
                            NormalizedUserName = "SECRETARY",
                            PasswordHash = "AQAAAAEAACcQAAAAEBp1LTi3PrSKUmJ3pT0wwnO1cNfRgMgDv4j1TC+C9X7PGCCk22WEdLZIxsEmox0QIQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "94d2105c-09c1-48ad-87b3-d4f09679c945",
                            TwoFactorEnabled = false,
                            UserName = "Secretary",
                            FirstName = "Samar",
                            LastName = "Bazzal"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5535b902-6b6f-477d-9682-ae636b77aeed",
                            Email = "hsayn.bazzal666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "HSAYN.BAZZAL666@GMAIL.com",
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEFn963xklBUYP77hBK1rapnJNlZilp972RKOuCtIThc+ydyTJ1z2CJD0XyGRrG13Yg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3997bc95-705a-4e0b-bdb0-938a45f82ed4",
                            TwoFactorEnabled = false,
                            UserName = "Manager",
                            FirstName = "Hsayn",
                            LastName = "Bazzal"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PPT.Models.Attendance", b =>
                {
                    b.HasOne("PPT.Models.Doctor", "Doctor")
                        .WithMany("Attendances")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.HasOne("PPT.Models.User", "Secretary")
                        .WithMany()
                        .HasForeignKey("SecretaryID");

                    b.HasOne("PPT.Models.Section", "Section")
                        .WithMany("Departments")
                        .HasForeignKey("SectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Secretary");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.HasOne("PPT.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("PPT.Models.Section", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
