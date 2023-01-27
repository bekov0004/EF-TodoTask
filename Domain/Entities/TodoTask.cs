using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TodoTask  
{ 
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime timestamps { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public int CategoryId { get; set; }
    public Category Category{ get; set; }
    public List<User> Users { get; set; }
    public List<Comment> Comments { get; set; }
}