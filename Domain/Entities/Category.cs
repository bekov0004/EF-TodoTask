using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; }
    public List<TodoTask> TodoTasks { get; set; }
}