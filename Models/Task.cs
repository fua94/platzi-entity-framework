using System.Text.Json.Serialization;

namespace home.Models;

public class Task
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreateAt { get; set; }
    public int Effort { get; set; }
    public virtual Category Category { get; set; }
    [JsonIgnore]
    public string Summary { get; set; }
}

public enum Priority
{
    Low,
    Normal,
    High
}