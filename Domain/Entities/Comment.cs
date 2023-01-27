using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Comment
{ 
    public int Id { get; set; }   
    [Required(ErrorMessage = "This field is required")]
    public int TodoTaskId{ get; set; }
    public TodoTask TodoTask { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string UserName { get; set; }
    public User Usere { get; set; }
    public string CommentText { get; set; }
}