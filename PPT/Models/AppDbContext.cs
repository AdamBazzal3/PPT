using Microsoft.EntityFrameworkCore;

namespace PPT.Models
{
    public class AppDbContext : DbContext
    {
        DbSet<Doctor> doctors { get; set; }
        DbSet<Attendance> attendances { get; set; }
        DbSet<Department> departments { get; set; }
        DbSet<Section> sections { get; set; }
        DbSet<Faculty> faculty { get; set; }
    }
}
