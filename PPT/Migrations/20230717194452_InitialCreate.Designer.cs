﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPT.Data;

#nullable disable

namespace PPT.Migrations
{
    [DbContext(typeof(PPTDatacontext))]
    [Migration("20230717194452_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = "507e0167-8198-4670-8a61-1a5972bc64bd",
                            ConcurrencyStamp = "30188587-409c-48d4-b92d-e4a8b5b8b991",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "a1633827-8461-475a-a892-57c15c26537c",
                            ConcurrencyStamp = "678ebe0a-30d6-4e10-89c9-6c55212b88cd",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "23e49706-2d15-455b-afb0-ec5aeefd466d",
                            ConcurrencyStamp = "7d451343-6532-42f6-be9f-777b9a38c7f6",
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
                            RoleId = "507e0167-8198-4670-8a61-1a5972bc64bd"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            RoleId = "a1633827-8461-475a-a892-57c15c26537c"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            RoleId = "a1633827-8461-475a-a892-57c15c26537c"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            RoleId = "23e49706-2d15-455b-afb0-ec5aeefd466d"
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
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7422),
                            DoctorID = 3,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 2,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7469),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 3,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7474),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 4,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7479),
                            DoctorID = 2,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 5,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7483),
                            DoctorID = 7,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 6,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7488),
                            DoctorID = 8,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 7,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7493),
                            DoctorID = 9,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 8,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7496),
                            DoctorID = 10,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 9,
                            Date = new DateTime(2023, 7, 17, 22, 44, 52, 163, DateTimeKind.Local).AddTicks(7500),
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

                    b.Property<string>("DirectorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FacultyID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DirectorID");

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
                            DirectorID = "8e445865-a24d-4543-i9i9-9443d048cdb9",
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

                    b.Property<string>("HeadID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecretaryID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("BranchID");

                    b.HasIndex("HeadID");

                    b.HasIndex("SecretaryID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BranchID = 2,
                            HeadID = "8e445865-a24d-4543-a6c6-9443d048cdb9",
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

                    b.Property<string>("DeanID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DeanID");

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
                            ConcurrencyStamp = "8ae28058-96f1-4eb2-a933-5423de89e1b3",
                            Email = "zainab.alsaghir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEL3Oujb1UzljmLuPUdhhNOu3mCYWwRLlVWsafZ8mt5UTciz3s/K0tiHrmBUvZ6njMg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "59f0576e-fb18-468a-be9e-57d63b180520",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            FirstName = "زينب ",
                            LastName = "الصغير"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "80dbbc30-fa39-4c7d-8cd1-2d2d064795e7",
                            Email = "hanaa666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARY",
                            PasswordHash = "AQAAAAEAACcQAAAAEAy9p+LvSIeju219sxno/JlAY9yOYFXsP2/MPba2c1d1J0BWQTqkSxhAeNhif5r0mw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bfebfc24-852d-4dc5-89d9-87d30cf13560",
                            TwoFactorEnabled = false,
                            UserName = "Secretary",
                            FirstName = "هناء",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61b7531b-2549-47d7-bb4e-e25e4c105e04",
                            Email = "bassem666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARYBASSEM",
                            PasswordHash = "AQAAAAEAACcQAAAAEL5t05yGV8lbGZj7G+6s0QTHOhx3EKNGGY7TJJj7CB15KHPyVofKjvGm0cv9x7PrzA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "395eee4f-7123-402c-9db2-bd1aa9377cda",
                            TwoFactorEnabled = false,
                            UserName = "SecretaryBassem",
                            FirstName = "باسم",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a0803a2a-7db5-44b4-bf74-b075805d6f13",
                            Email = "hsayn.bazzi666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ3temwZRugqCuOG6CU9OUE6XlEeeIPd02H//AyQVCP/OiggKDx2hz+yOHxmKr2vjw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "70a83366-2002-45c1-8394-325b60970668",
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
                    b.HasOne("PPT.Models.User", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorID");

                    b.HasOne("PPT.Models.Faculty", "Faculty")
                        .WithMany("Branches")
                        .HasForeignKey("FacultyID");

                    b.Navigation("Director");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("PPT.Models.Department", b =>
                {
                    b.HasOne("PPT.Models.Branch", "Branch")
                        .WithMany("Departments")
                        .HasForeignKey("BranchID");

                    b.HasOne("PPT.Models.User", "Head")
                        .WithMany()
                        .HasForeignKey("HeadID");

                    b.HasOne("PPT.Models.User", "Secretary")
                        .WithMany()
                        .HasForeignKey("SecretaryID");

                    b.Navigation("Branch");

                    b.Navigation("Head");

                    b.Navigation("Secretary");
                });

            modelBuilder.Entity("PPT.Models.Doctor", b =>
                {
                    b.HasOne("PPT.Models.Department", "Department")
                        .WithMany("Doctors")
                        .HasForeignKey("DepartmentID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("PPT.Models.Faculty", b =>
                {
                    b.HasOne("PPT.Models.User", "Dean")
                        .WithMany()
                        .HasForeignKey("DeanID");

                    b.Navigation("Dean");
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