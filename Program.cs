//using entity_framework.src.Classes;
//using entity_framework.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<HomeworkContext>(p => p.UseInMemoryDatabase("HomeworkDB"));
builder.Services.AddDbContext<HomeworkContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnHomework")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] HomeworkContext DbContext) => 
{
	DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + DbContext.Database.IsInMemory());
});

app.MapGet("/api/homeworks", async ([FromServices] HomeworkContext DbContext ) =>
{
	return Results.Ok(DbContext.Homeworks);
});

app.Run();
