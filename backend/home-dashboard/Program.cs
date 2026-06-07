var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] people = { "Ben", "Rory", "Jamie" };


List<MoistureReading> moistureReadings = new() { new MoistureReading(2303, 50), new MoistureReading(3304, 68) };

app.UseHttpsRedirection();

app.MapGet("/people", () =>
    {
        return people;
    });

app.MapGet("/readings", () =>
    {
        List<int> readingsArray = new List<int>();

        for (int i = 0; i < moistureReadings.Count; i++)
        {
            readingsArray.Add(moistureReadings[i].MoisturePercent);
        }

        return readingsArray;
    });

app.MapGet("/people/{id}", (int id) =>
    {
        return people[id];
    });

app.Run();

class MoistureReading
{
    public int MoistureRaw;
    public int MoisturePercent;
    public DateTime time = DateTime.UtcNow;

    public MoistureReading(int moistureRaw, int moisturePercent)
    {
        MoistureRaw = moistureRaw;
        MoisturePercent = moisturePercent;
    }
}
