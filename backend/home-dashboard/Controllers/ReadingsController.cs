using HomeDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ReadingsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ReadingsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var readings = await _db.MoistureReadings.ToListAsync();

        return Ok(readings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(String id)
    {
        var reading = await _db.MoistureReadings.FindAsync(id);

        if (reading == null)
        {
            return NotFound("Couldn't find reading with this ID");
        }

        return Ok(reading);
    }

    [HttpPost]
    public async Task<IActionResult> Create(MoistureReading reading)
    {
        _db.MoistureReadings.Add(reading);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = reading.Id }, reading);
    }
}
