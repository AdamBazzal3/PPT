using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PPT.Data;
using PPT.Models;
using PPT.Repositories;
using PPT.Services;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PPTDatacontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PPTContext")));
builder.Services.AddIdentity<User, IdentityRole>()
    .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<PPTDatacontext>();
builder.Services.AddScoped<IRepository<Doctor>, SqlServerRepository<Doctor>>();
builder.Services.AddScoped<IRepository<Attendance>, SqlServerRepository<Attendance>>();
//builder.Services.AddSingleton<IRepository<Department>, SqlServerRepository<Department>>();
//builder.Services.AddSingleton<IAuthService, AuthService>();

//var connString = Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<AppDbContext>(
//                      options => options.UseSqlServer(connString)
//                      );
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
