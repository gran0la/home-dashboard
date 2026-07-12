using HomeDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[Controller]")]
public class PlantsController : ControllerBase
{
    private readonly AppDbContext _db;

    public PlantsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var plants = await _db.Plants.ToListAsync();

        if (plants == null)
        {
            return NotFound("No plants found");
        }

        return Ok(plants);
    }

    [HttpGet("{id}/readings")]
    public async Task<IActionResult> GetAllPlantReadings(String id)
    {
        var readings = await _db.MoistureReadings.Where(r => r.PlantId == id).ToListAsync();

        if (readings == null)
        {
            return NotFound("No readings found for this ID");
        }

        return Ok(readings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(string id)
    {
        var plants = await _db.Plants.FindAsync(id);

        if (plants == null)
        {
            return NotFound("No plants found with this ID");
        }

        return Ok(plants);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Plant plant)
    {
        _db.Add(plant);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = plant.Id }, plant);
    }
}
