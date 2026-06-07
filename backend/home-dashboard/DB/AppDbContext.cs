using Microsoft.EntityFrameworkCore;
using HomeDashboard.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<MoistureReading> MoistureReadings { get; set; }
}
