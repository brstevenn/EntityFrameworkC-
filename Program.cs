//using entity_framework.src.Classes;
//using entity_framework.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework;
using EntityFramework.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<HomeworkContext>(p => p.UseInMemoryDatabase("HomeworkDB"));
builder.Services.AddDbContext<HomeworkContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnHomework")));
//builder.Services.AddDbContext<CategoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("cnCategory")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] HomeworkContext DbContext) => 
{
	DbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + DbContext.Database.IsInMemory());
});

app.MapGet("/api/homeworks", async ([FromServices] HomeworkContext DbContext ) =>
{
	return Results.Ok(DbContext.Homeworks.Include(p => p.Category));//.Where(p => p.PriorityHomework == EntityFramework.Models.Priority.Low));
});

app.MapGet("/api/homeworks/name", async ([FromServices] HomeworkContext DbContext ) =>
{
	return Results.Ok(DbContext.Homeworks.Include(p => p.Category).Where(p => p.Title == "Pago de servicios"));
});

app.MapPost("/api/homeworks", async ([FromServices] HomeworkContext DbContext , [FromBody] Homework homework) =>
{
	DateTime localDateTime = DateTime.Now;
	DateTime utcDateTime = localDateTime.ToUniversalTime();
	homework.HomeworkId = Guid.NewGuid();
	homework.CreationDate = utcDateTime;
	await DbContext.AddAsync(homework);
	await DbContext.SaveChangesAsync();
	return Results.Ok();
});

app.MapPut("/api/homeworks/{id}", async ([FromServices] HomeworkContext DbContext , [FromBody] Homework homework, [FromRoute] Guid id) =>
{
	var homeworkCurrent = DbContext.Homeworks.Find(id);

	if(homeworkCurrent != null)
	{
		homeworkCurrent.CategoryId = homework.CategoryId;
		homeworkCurrent.Title = homework.Title;
		homeworkCurrent.PriorityHomework = homework.PriorityHomework;
		homeworkCurrent.Description = homework.Description;
		homeworkCurrent.Process = homework.Process;
	
		await DbContext.SaveChangesAsync();

		return Results.Ok();
	}
	
	return Results.NotFound();
});

app.MapDelete("/api/homeworks/{id}", async ([FromServices] HomeworkContext DbContext, [FromRoute] Guid id) =>
{
	var homeworkCurrent = DbContext.Homeworks.Find(id);

	if(homeworkCurrent != null)
	{
		DbContext.Remove(homeworkCurrent);
		await DbContext.SaveChangesAsync();
		return Results.Ok();
	}

	return Results.NotFound();
});



app.MapGet("/api/categories", async ([FromServices] HomeworkContext DbContext ) =>
{
	return Results.Ok(DbContext.Categories.Include(p => p.Homework));
});

app.MapPost("/api/categories", async ([FromServices] HomeworkContext DbContext , [FromBody] Category category) =>
{
	category.CategoryId = Guid.NewGuid();
	await DbContext.Categories.AddAsync(category);
	await DbContext.SaveChangesAsync();
	return Results.Ok();
});

app.MapPut("/api/categories/{id}", async ([FromServices] HomeworkContext DbContext , [FromBody] Category category, [FromRoute] Guid id) =>
{
	var categoryCurrent = DbContext.Categories.Find(id);

	if(categoryCurrent != null)
	{
		categoryCurrent.Name = category.Name;
		categoryCurrent.Description = category.Description;
		categoryCurrent.Weight = category.Weight;
	
		await DbContext.SaveChangesAsync();

		return Results.Ok();
	}
	
	return Results.NotFound();
});

app.MapDelete("/api/categories/{id}", async ([FromServices] HomeworkContext DbContext, [FromRoute] Guid id) =>
{
	var categoryCurrent = DbContext.Categories.Find(id);

	if(categoryCurrent != null)
	{
		DbContext.Remove(categoryCurrent);
		await DbContext.SaveChangesAsync();
		return Results.Ok();
	}

	return Results.NotFound();
});

app.Run();
