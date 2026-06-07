namespace HomeDashboard.Models;

class MoistureReading
{
    public string Id { get; set; }
    public string PlantId { get; set; }
    public Plant Plant { get; set; }
    public int MoistureRaw { get; set; }
    public int MoisturePercent { get; set; }
    public DateTime time { get; set; }
}
