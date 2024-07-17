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
    modelBuilder.Entity<Category>(category =>
    {
      category.ToTable("Category");
      category.HasKey(c => c.Id);
      category.Property(c => c.Name).IsRequired().HasMaxLength(150);
      category.Property(c => c.Description);
    });

    modelBuilder.Entity<Models.Task>(task =>
    {
      task.ToTable("Task");
      task.HasKey(t => t.Id);
      task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);
      task.Property(t => t.Title).IsRequired().HasMaxLength(200);
      task.Property(t => t.Description);
      task.Property(t => t.Priority);
      task.Property(t => t.CreateAt);
      task.Property(t => t.Effort);
      task.Ignore(t => t.Summary);
    });
  }
}