namespace HomeDashboard.Models;

public class Plant
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Name { get; set; }
    public int MoistureThreshold { get; set; }
}
