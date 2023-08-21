using Microsoft.EntityFrameworkCore;
using Pronia.Core.Entities;

namespace Pronia.DbC.Contexts;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    { 
    }

    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;

}
