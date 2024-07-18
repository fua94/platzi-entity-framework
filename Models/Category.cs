using System.Text.Json.Serialization;
namespace home.Models;

public class Category
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  [JsonIgnore]
  public virtual ICollection<Models.Task> Tasks { get; set; }
}