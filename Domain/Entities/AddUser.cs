using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class AddUser
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required"),MaxLength(50)] 
    public string UserName { get; set; }
    public User User { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public int TodoTaskId { get; set; }
    public TodoTask TodoTask{ get; set; }
}