using HomeDashboard.Models;
using Microsoft.EntityFrameworkCore;

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

app.UseHttpsRedirection();

app.MapGet("/people", () =>
    {
        return people;
    });

app.MapGet("/people/{id}", (int id) =>
    {
        return people[id];
    });

app.Run();
