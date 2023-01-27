using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddUserInTask
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required"),MaxLength(50)] 
    public string UserName { get; set; } 
    [Required(ErrorMessage = "This field is required")]
    public int TodoTaskId { get; set; } 
}