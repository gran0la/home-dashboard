using HomeDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class WaterEventsController : ControllerBase
{
    private readonly AppDbContext _db;

    public WaterEventsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _db.WaterEvents.ToListAsync();

        if (events == null)
        {
            return NotFound("No events found");
        }

        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(String id)
    {
        var waterEvent = await _db.WaterEvents.FindAsync(id);

        if (waterEvent == null)
        {
            return NotFound("Couldn't find water event with this id");
        }

        return Ok(waterEvent);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WaterEvent waterEvent)
    {
        _db.WaterEvents.Add(waterEvent);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = waterEvent.Id }, waterEvent);
    }
}
