using home;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddNpgsql<TasksContext>(builder.Configuration.GetConnectionString("TasksDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconection", async ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("DB Server is ready: " + dbContext.Database.IsNpgsql());
});

app.Run();
