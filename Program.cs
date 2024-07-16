using home;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<TasksContext>(@"Host=127.0.0.1:5435;Username=postgres;Password=root;Database=Tasks");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconection", async ([FromServices] TasksContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("DB Server is ready: " + dbContext.Database.IsNpgsql());
});

app.Run();
