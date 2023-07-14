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
                            Id = "dba50297-4d97-4e8b-bfbb-92de2e10c098",
                            ConcurrencyStamp = "62e5f184-fd0d-436b-a1f2-e03ceb7d0e9f",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "df419d50-0d8f-4236-ac74-257be2245a87",
                            ConcurrencyStamp = "526a412c-3a47-4faf-a42b-643cad415592",
                            Name = "Secretary",
                            NormalizedName = "SECRETARY"
                        },
                        new
                        {
                            Id = "d7d33197-d923-4be8-bea0-a34f717699d5",
                            ConcurrencyStamp = "eb24bf24-cb45-4cea-90ca-5fed3a515c9f",
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
                            RoleId = "dba50297-4d97-4e8b-bfbb-92de2e10c098"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            RoleId = "df419d50-0d8f-4236-ac74-257be2245a87"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            RoleId = "df419d50-0d8f-4236-ac74-257be2245a87"
                        },
                        new
                        {
                            UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            RoleId = "d7d33197-d923-4be8-bea0-a34f717699d5"
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

                    b.HasIndex("DoctorID");

                    b.ToTable("Attendances");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 3,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 3,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 1,
                            IsPublished = false
                        },
                        new
                        {
                            ID = 4,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorID = 2,
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

                    b.Property<bool?>("IsContracted")
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
                            Name = "علي غريب"
                        },
                        new
                        {
                            ID = 2,
                            DepartmentID = 1,
                            Name = "محمد دبوق"
                        },
                        new
                        {
                            ID = 3,
                            DepartmentID = 1,
                            Name = "كمال بيضون"
                        },
                        new
                        {
                            ID = 4,
                            DepartmentID = 1,
                            Name = "أحمد فاعور"
                        },
                        new
                        {
                            ID = 5,
                            DepartmentID = 2,
                            Name = "سامر"
                        },
                        new
                        {
                            ID = 6,
                            DepartmentID = 2,
                            Name = "أحمد"
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
                            ConcurrencyStamp = "274f9539-ca4b-455c-8076-e3b8d3670eb6",
                            Email = "zainab.alsaghir@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEJpER3rd6DHsn8kiUrBR9wchsN1DwpIdChXqbaU0cvgdUc+Qg8ART3lzyVivOApVfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9bf6225f-2391-4ed7-8ed7-ca70aa10e33c",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            FirstName = "زينب ",
                            LastName = "الصغير"
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6fa7e5fb-369a-449b-9d9b-b9446a12eea4",
                            Email = "hanaa666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARY",
                            PasswordHash = "AQAAAAEAACcQAAAAECO0gKbJIk+hh89WWcPPh8GE0HcHhZ32DosTKeHSdspbdI3hFjEZ2D+oI1BVYYGTgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "73a09207-7dab-49de-9654-5a7f6c1ebe79",
                            TwoFactorEnabled = false,
                            UserName = "Secretary",
                            FirstName = "هناء",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-9O9O-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5d484012-c019-421a-9b32-98bdd221b1ba",
                            Email = "bassem666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "SECRETARYBASSEM",
                            PasswordHash = "AQAAAAEAACcQAAAAEG6Ba++2kYYUKYkum/gzArEXnCqK4L4D5Q5HaJyZ+23xCpkkSOpKn9qLW3yDS3Mlzw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e2f2d824-ec86-4aaf-8e71-4eccb6b1d388",
                            TwoFactorEnabled = false,
                            UserName = "SecretaryBassem",
                            FirstName = "باسم",
                            LastName = ""
                        },
                        new
                        {
                            Id = "8e445865-a24d-4543-i9i9-9443d048cdb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ccb881c0-9ce6-46ae-92be-0b6850459860",
                            Email = "hsayn.bazzi666@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "MANAGER",
                            PasswordHash = "AQAAAAEAACcQAAAAEPfQpbYH/R00NII4LRRcYsTml6/Tp7y+glB/eRzlKBnfYXJENUdDGz/3qYtOTdxT2g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8de3bc02-6d3e-4f29-b828-77a06fad803c",
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
