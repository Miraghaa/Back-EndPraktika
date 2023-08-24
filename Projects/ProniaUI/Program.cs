using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pronia.Buisness.Mappers;
using Pronia.Buisness.Services.Implementations;
using Pronia.Buisness.Services.Interfaces;
using Pronia.Core.Entities;
using Pronia.DbC.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(SliderProfile).Assembly);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<AppDbContextInitializer>();

builder.Services.AddIdentity<AppUser,IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;

    options.User.RequireUniqueEmail = true;

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IFileService,FileService>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var instance = provider.GetRequiredService<AppDbContextInitializer>();
    await instance.Initialize();
    await instance.CreateRole();
    await instance.CreateAdmin();
}
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.UseAuthentication();
app.UseAuthorization();
 app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();