using HomeDashboard.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ReadingsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ReadingsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create(MoistureReading reading)
    {
        _db.MoistureReadings.Add(reading);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = reading.Id }, reading);
    }
}
