using HomeDashboard.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString =
        builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] people = { "Ben", "Rory", "Jamie" };

app.UseHttpsRedirection();

app.MapGet("/people", () =>
    {
        return people;
    });

app.MapPost("/readings", async (MoistureReading reading, AppDbContext db) =>
{
    db.MoistureReadings.Add(reading);

    await db.SaveChangesAsync();

    return Results.Created($"/reading/{reading.Id}", reading);
});

app.MapGet("/people/{id}", (int id) =>
    {
        return people[id];
    });

app.Run();
