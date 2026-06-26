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
            return NotFound("No plant readings found");
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
