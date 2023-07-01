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
                            Id = "4aa8fd5d-dda6-4891-b7ee-1e57def6c035",
                            ConcurrencyStamp = "5f63276a-07da-4502-bacd-e6e0d7a34fa2",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "de43b4d8-773c-4bc9-9161-7ea2b7c1da61",
                            ConcurrencyStamp = "8300657d-f965-46e3-957e-222d227a0a07",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "5623606f-c99a-4350-84cb-ed3008f6eb3d",
                            ConcurrencyStamp = "79209ce3-282f-4b4b-9b8a-3699af1d5f56",
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
                            RoleId = "4aa8fd5d-dda6-4891-b7ee-1e57def6c035"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            RoleId = "de43b4d8-773c-4bc9-9161-7ea2b7c1da61"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            RoleId = "de43b4d8-773c-4bc9-9161-7ea2b7c1da61"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            RoleId = "5623606f-c99a-4350-84cb-ed3008f6eb3d"
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

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPublished")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID", "Date")
                        .IsUnique()
                        .HasFilter("[DoctorID] IS NOT NULL");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2495),
                            DoctorID = 3,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 2,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2532),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 3,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2535),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 4,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2538),
                            DoctorID = 2,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 5,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2541),
                            DoctorID = 7,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 6,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2544),
                            DoctorID = 8,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 7,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2547),
                            DoctorID = 9,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 8,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2549),
                            DoctorID = 10,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 9,
                            Date = new DateTime(2023, 7, 1, 14, 36, 21, 824, DateTimeKind.Local).AddTicks(2552),
                            DoctorID = 11,
                            IsPublished = false
                        });
                });

            modelBuilder.Entity("PPT.Models.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("FacultyID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("FacultyID");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "زحلة"
                        },
                        new
                        {
                            ID = 2,
                            Name = "الحدت"
                        });
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretaryID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("BranchID");

                    b.HasIndex("SecretaryID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BranchID = 2,
                            Name = "Computer science and mathmatics",
                            SecretaryID = "8e445865-a24d-4543-7u7u-9443d048cdb9"
                        },
                        new
                        {
                            ID = 2,
                            BranchID = 1,
                            Name = "Physics",
                            SecretaryID = "8e445865-a24d-4543-9O9O-9443d048cdb9"
                        },
                        new
                        {
                            ID = 3,
                            BranchID = 1,
                            Name = "Chemistry"
                        },
                        new
                        {
                            ID = 4,
                            BranchID = 2,
                            Name = "Biochemistry"
                        });
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<bool>("IsContracted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            IsContracted = true,
                            Name = "علي غريب"
                        },
                        new
                        {
                            ID = 2,
                            DepartmentID = 1,
                            IsContracted = true,
                            Name = "محمد دبوق"
                        },
                        new
                        {
                            ID = 3,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "كمال بيضون"
                        },
                        new
                        {
                            ID = 4,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "أحمد فاعور"
                        },
                        new
                        {
                            ID = 5,
                            DepartmentID = 2,
                            IsContracted = false,
                            Name = "سامر"
                        },
                        new
                        {
                            ID = 6,
                            DepartmentID = 2,
                            IsContracted = false,
                            Name = "أحمد"
                        },
                        new
                        {
                            ID = 7,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "خالد نجار"
                        },
                        new
                        {
                            ID = 8,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "محمد حسن"
                        },
                        new
                        {
                            ID = 9,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "فاطمة صالح"
                        },
                        new
                        {
                            ID = 10,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "ياسر مصطفى"
                        },
                        new
                        {
                            ID = 11,
                            DepartmentID = 1,
                            IsContracted = false,
                            Name = "نورا محمود"
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
                            Name = "كلية العلوم"
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
                            ConcurrencyStamp = "47552ed1-621f-43a3-bd24-7e4014672414",
                            Email = "zainab.alsaghir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEHoxIVf9uGUmzEYFWELsBw5iyIaqMxQNzvhQrAZ6cGkj4PEJPijFSeTp3VwrHl2xug==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d2f3742d-0d94-4380-b9fd-8d813a4d1759",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            FirstName = "زينب ",
                            LastName = "الصغير"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3179fd12-941a-4194-a798-386dae7d1071",
                            Email = "hanaa666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARY",
                            PasswordHash = "AQAAAAEAACcQAAAAENEPLyzuOPhLuGT5rzeYQmSUd6LrzNYkzbaCKNpxUTnh/maE+ta3VuInWt6yUdaXWQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9ea6467c-bc40-4d6b-bea2-5d5265dd5db4",
                            TwoFactorEnabled = false,
                            UserName = "Secretary",
                            FirstName = "هناء",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aa170e0a-c27a-4b6b-8667-1eb9801a37a0",
                            Email = "bassem666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARYBASSEM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE+mat29imaRyJ28hxlLNIZy42ejZRt85/nvMtu4BcaOLTVyPSJX6HjeCNcGCipaLw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "45cbb50c-de69-402e-9b19-391a646ee5d8",
                            TwoFactorEnabled = false,
                            UserName = "SecretaryBassem",
                            FirstName = "باسم",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8b1f6634-e581-4f9a-a527-807d94561306",
                            Email = "hsayn.bazzi666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOugTmnXAVyebHiZvcmpo7IU4/rQTLTxBLF4A1aExkVgQqgFLdq+8ynr0SHAMzOWYg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4b369548-2cb9-4ffd-9919-475f43670828",
                            TwoFactorEnabled = false,
                            UserName = "Manager",
                            FirstName = "حسين",
                            LastName = "بزي"
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
                        .HasForeignKey("DoctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("PPT.Models.Branch", b =>
                {
                    b.HasOne("PPT.Models.Faculty", "Faculty")
                        .WithMany("Branches")
                        .HasForeignKey("FacultyID");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.HasOne("PPT.Models.Branch", "Branch")
                        .WithMany("Departments")
                        .HasForeignKey("BranchID");

                    b.HasOne("PPT.Models.User", "Secretary")
                        .WithMany()
                        .HasForeignKey("SecretaryID");

                    b.Navigation("Branch");

                    b.Navigation("Secretary");
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.HasOne("PPT.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("PPT.Models.Branch", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.Navigation("Attendances");
                });

            modelBuilder.Entity("PPT.Models.Faculty", b =>
                {
                    b.Navigation("Branches");
                });
#pragma warning restore 612, 618
        }
    }
}
