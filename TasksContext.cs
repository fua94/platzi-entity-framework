using home.Models;
using Microsoft.EntityFrameworkCore;

namespace home;

public class TasksContext : DbContext
{
  public DbSet<Category> Categories { get; set; }
  public DbSet<Models.Task> Tasks { get; set; }

  public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoriesInit = new List<Category>();
    categoriesInit.Add(new Category() { Id = Guid.Parse("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"), Name = "Pendientes" });
    categoriesInit.Add(new Category() { Id = Guid.Parse("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c1"), Name = "Completadas" });
    categoriesInit.Add(new Category() { Id = Guid.Parse("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c2"), Name = "En progreso" });

    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(c => c.Id);
      category.Property(c => c.Name).IsRequired().HasMaxLength(150);
      category.Property(c => c.Description).IsRequired(false);
      category.HasData(categoriesInit);
    });

    List<Models.Task> tasksInit = new List<Models.Task>();
    tasksInit.Add(new Models.Task()
    {
      Id = Guid.Parse("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c3"),
      CategoryId = Guid.Parse("17f5abc5-59ef-4564-acfe-ae4cb8c0a6c0"),
      Title = "MVP proyecto tareas",
      Priority = Priority.High,
      CreateAt = DateTime.Now,
      Effort = 9
    });

    modelBuilder.Entity<Models.Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(t => t.Id);
      task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
      task.Property(t => t.Title).IsRequired().HasMaxLength(200);
      task.Property(t => t.Description).IsRequired(false);
      task.Property(t => t.Priority);
      task.Property(t => t.CreateAt);
      task.Property(t => t.Effort).HasMaxLength(10);
      task.Ignore(t => t.Summary);
      task.HasData(tasksInit);
    });
  }
}