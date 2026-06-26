using HomeDashboard.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<MoistureReading> MoistureReadings { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<WaterEvent> WaterEvents { get; set; }
}
