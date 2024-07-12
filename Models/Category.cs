using System.ComponentModel.DataAnnotations;

namespace home.Models;

public class Category
{
  [Key]
  public Guid Id { get; set; }
  [Required]
  [MaxLength(150)]
  public string Name { get; set; }
  public string Description { get; set; }
  public virtual ICollection<Models.Task> Tasks { get; set; }
}