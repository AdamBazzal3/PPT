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
    public DbSet<Section> Sections { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

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
                FirstName = "Adam",
                LastName = "Bazzal",
                Email="adam.bazzal666@gmail.com",
                NormalizedEmail = "ADAM.BAZZAL666@GMAIL.com",
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Samar",
                LastName = "Bazzal",
                Email = "samar.bazzal666@gmail.com",
                NormalizedEmail = "SAMAR.BAZZAL666@GMAIL.com",
                Id = "8e445865-a24d-4543-7u7u-9443d048cdb9", // primary key
                UserName = "Secretary",
                NormalizedUserName = "SECRETARY",
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                EmailConfirmed = true
            },
            new User
            {
                FirstName = "Hsayn",
                LastName = "Bazzal",
                Id = "8e445865-a24d-4543-i9i9-9443d048cdb9", // primary key
                UserName = "Manager",
                Email = "hsayn.bazzal666@gmail.com",
                NormalizedEmail = "HSAYN.BAZZAL666@GMAIL.com",
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
                RoleId = managerId,
                UserId = "8e445865-a24d-4543-i9i9-9443d048cdb9"
            }
        );

        builder.Entity<Faculty>().HasData(
            new Faculty
            {
                ID = 1,
                Name = "Faculty of Sciences",
            }
        );

        builder.Entity<Section>().HasData(
            new Section
            {
                ID = 1,
                Name = "Zahle",
            },
            new Section
            {
                ID = 2,
                Name = "Hadath",
            }
        );

        builder.Entity<Department>().HasData(
            new Department
            {
                ID = 1,
                Name = "Computer science and mathmatics",
                SectionID = 2,
                SecretaryID = "8e445865-a24d-4543-7u7u-9443d048cdb9"
            },
            new Department
            {
                ID = 2,
                Name = "Physics",
                SectionID = 1
            },
            new Department
            {
                ID = 3,
                Name = "Chemistry",
                SectionID = 1
            },
            new Department
            {
                ID = 4,
                Name = "Biochemistry",
                SectionID = 2
            }
        );

        builder.Entity<Doctor>().HasData(
            new Doctor
            {
                ID = 1,
                Name = "علي غريب",
                DepartmentID = 1
            },
            new Doctor
            {
                ID = 2,
                Name = "محمد دبوق",
                DepartmentID = 1
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
        );

        builder.Entity <Attendance>().HasData(
            new Attendance
            {
                ID = 1,
                DoctorID = 3,
                IsPublished = false
            },
            new Attendance
            {
                ID = 2,
                DoctorID = 1,
                IsPublished = false
            },
            new Attendance
            {
                ID = 3,
                DoctorID = 1,
                IsPublished = false
            },
            new Attendance
            {
                ID = 4,
                DoctorID = 2,
                IsPublished = false
            }
        );
    }
}
