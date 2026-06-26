namespace HomeDashboard.Models;

public class WaterEvent
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? PlantId { get; set; }
    public DateTime WateredAt { get; set; }
    public double DurationSeconds { get; set; }
}
