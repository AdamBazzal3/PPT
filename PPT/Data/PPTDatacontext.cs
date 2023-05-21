using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PPT.Models;

namespace PPT.Data;

public class PPTDatacontext : IdentityDbContext<User>
{
    public PPTDatacontext(DbContextOptions<PPTDatacontext> options)
        : base(options)
    {
    }
    public DbSet<User> users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
