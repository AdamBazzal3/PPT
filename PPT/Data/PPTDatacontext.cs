using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPT.Models;
using System.Reflection.Emit;

namespace PPT.Data;

public class PPTDatacontext : IdentityDbContext
{
    public PPTDatacontext(DbContextOptions<PPTDatacontext> options)
        : base(options)
    {
    }
    public DbSet<User> users { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Branch> Branches { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<Attendance>()
        .HasIndex(a => new { a.DoctorID, a.Date })
        .IsUnique();
        string adminId = Guid.NewGuid().ToString();
        string managerId = Guid.NewGuid().ToString();
        string secretaryId = Guid.NewGuid().ToString();

        //Seeding a  'Administrator' role to AspNetRoles table
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = adminId, Name = "Administrator", NormalizedName = "ADMINISTRATOR".ToUpper() });
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = secretaryId, Name = "Secretary", NormalizedName = "SECRETARY".ToUpper() });
        builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = managerId, Name = "Manager", NormalizedName = "MANAGER".ToUpper() });

        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<User>();


        //Seeding the User to AspNetUsers table
        builder.Entity<User>().HasData(
            new User
            {
                FirstName = "زينب ",
                LastName = "الصغير",
                Email="zainab.alsaghir@gmail.com",
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "هناء",
                LastName = "",
                Email = "hanaa666@gmail.com",
                Id = "8e445865-a24d-4543-7u7u-9443d048cdb9", // primary key
                UserName = "Secretary",
                NormalizedUserName = "SECRETARY",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "باسم",
                LastName = "",
                Email = "bassem666@gmail.com",
                Id = "8e445865-a24d-4543-9O9O-9443d048cdb9", // primary key
                UserName = "SecretaryBassem",
                NormalizedUserName = "SECRETARYBASSEM",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "حسين",
                LastName = "بزي",
                Id = "8e445865-a24d-4543-i9i9-9443d048cdb9", // primary key
                UserName = "Manager",
                Email = "hsayn.bazzi666@gmail.com",
                NormalizedUserName = "MANAGER",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            }
        );


        //Seeding the relation between our user and role to AspNetUserRoles table
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminId,
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            },
            new IdentityUserRole<string>
            {
                RoleId = secretaryId,
                UserId = "8e445865-a24d-4543-7u7u-9443d048cdb9"
            },
            new IdentityUserRole<string>
            {
                RoleId = secretaryId,
                UserId = "8e445865-a24d-4543-9O9O-9443d048cdb9"
            },
            new IdentityUserRole<string>
            {
                RoleId = managerId,
                UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9"
            }
        );

        builder.Entity<Faculty>().HasData(
            new Faculty
            {
                ID = 1,
                Name = "كلية العلوم",
            }
        );

        builder.Entity<Branch>().HasData(
            new Branch
            {
                ID = 1,
                Name = "زحلة",
            },
            new Branch
            {
                ID = 2,
                Name = "الحدت",
                DirectorID = "8e445865-a24d-4543-i9i9-9443d048cdb9"
            }
        );

        builder.Entity<Department>().HasData(
            new Department
            {
                ID = 1,
                Name = "Computer science and mathmatics",
                BranchID = 2,
                SecretaryID = "8e445865-a24d-4543-7u7u-9443d048cdb9",
                HeadID = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            },
            new Department
            {
                ID = 2,
                Name = "Physics",
                BranchID = 1,
                SecretaryID = "8e445865-a24d-4543-9O9O-9443d048cdb9",

            },
            new Department
            {
                ID = 3,
                Name = "Chemistry",
                BranchID = 1
            },
            new Department
            {
                ID = 4,
                Name = "Biochemistry",
                BranchID = 2
            }
        );

        builder.Entity<Doctor>().HasData(
            new Doctor
            {
                ID = 1,
                Name = "علي غريب",
                DepartmentID = 1,
                IsContracted = true
            },
            new Doctor
            {
                ID = 2,
                Name = "محمد دبوق",
                DepartmentID = 1,
                IsContracted = true
            },
            new Doctor
            {
                ID = 3,
                Name = "كمال بيضون",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 4,
                Name = "أحمد فاعور",
                DepartmentID = 1
            }
            ,
            new Doctor
            {
                ID = 5,
                Name = "سامر",
                DepartmentID = 2
            },
            new Doctor
            {
                ID = 6,
                Name = "أحمد",
                DepartmentID = 2
            },
            new Doctor
            {
                ID = 7,
                Name = "خالد نجار",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 8,
                Name = "محمد حسن",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 9,
                Name = "فاطمة صالح",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 10,
                Name = "ياسر مصطفى",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 11,
                Name = "نورا محمود",
                DepartmentID = 1
            }
        );

        builder.Entity <Attendance>().HasData(
            new Attendance
            {
                ID = 1,
                DoctorID = 3,
                IsPublished = false,
                Date = DateTime.Now,
            },
            new Attendance
            {
                ID = 2,
                DoctorID = 1,
                IsPublished = false,
                Date = DateTime.Now,
            },
            new Attendance
            {
                ID = 3,
                DoctorID = 1,
                IsPublished = false,
                Date = DateTime.Now,
            },
            new Attendance
            {
                ID = 4,
                DoctorID = 2,
                IsPublished = false,
                Date = DateTime.Now
            },
            new Attendance
            {
                ID = 5,
                DoctorID = 7,
                IsPublished = false,
                Date = DateTime.Now
            },
            new Attendance
            {
                ID = 6,
                DoctorID = 8,
                IsPublished = false,
                Date = DateTime.Now
            },
            new Attendance
            {
                ID = 7,
                DoctorID = 9,
                IsPublished = false,
                Date = DateTime.Now
            },
            new Attendance
            {
                ID = 8,
                DoctorID = 10,
                IsPublished = false,
                Date = DateTime.Now
            },
            new Attendance
            {
                ID = 9,
                DoctorID = 11,
                IsPublished = false,
                Date = DateTime.Now
            }
        );
    }
}
