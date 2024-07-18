using home;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("TasksDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
  return Results.Ok(dbContext.Tasks.Include(p => p.Category));
});
app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] home.Models.Task task) =>
{
  task.Id = Guid.NewGuid();
  task.CreateAt = DateTime.Now;
  await dbContext.AddAsync(task);
  await dbContext.SaveChangesAsync();
  return Results.Ok();
});
app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] home.Models.Task task, [FromRoute] Guid id) =>
{
  var actualTask = await dbContext.Tasks.FindAsync(id);

  if (actualTask != null)
  {
    actualTask.CategoryId = task.CategoryId;
    actualTask.Title = task.Title;
    actualTask.Priority = task.Priority;
    actualTask.Description = task.Description;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }

  return Results.NotFound();
});
app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
  var actualTask = await dbContext.Tasks.FindAsync(id);

  if (actualTask != null)
  {
    dbContext.Remove(actualTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
  }

  return Results.NotFound();
});
app.MapGet("/dbconection", async ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("DB Server is ready: " + dbContext.Database.IsNpgsql());
});

app.Run();
