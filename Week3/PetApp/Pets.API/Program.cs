using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pets.Data;
using Pets.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Your key for connection string in user-secrets need to be of the format "ConnectionStrings:YourDbName" 
builder.Services.AddDbContext<PetsDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PetDB")));
builder.Services.AddScoped<IRepository, PetsRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

/*
app.MapGet("/pet", (IRepository repo) => {
    return repo.GetAllPets();
})
.WithName("Get All Pets")
.WithOpenApi();
*/

// app.MapPost("/pet", ([FromServices] IRepository repo, [FromBody] Pet petToCreate) => {
//     return repo.CreateNewPet(petToCreate);
// })
// .WithName("Create New Pet")
// .WithOpenApi();

app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
