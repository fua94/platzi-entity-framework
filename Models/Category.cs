namespace home.Models;

public class Category
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual ICollection<Models.Task> Tasks { get; set; }
}