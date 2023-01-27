using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class Register
{
    [Required(ErrorMessage = "Field Name is required"),MaxLength(50,ErrorMessage = "Max value 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Field Email is required"),MaxLength(70,ErrorMessage = "Max value 70 characters"),]
    public string Email { get; set; }
    [Required(ErrorMessage = "Field Phone is required"),MaxLength(20,ErrorMessage = "Max value 20 characters"),]
    public string Phone { get; set; } 
    [Required(ErrorMessage = "Field PassWord is required"),MinLength(5,ErrorMessage = "Minimum value 5 characters"),MaxLength(30,ErrorMessage = "Max value 25 characters")]
    public string PassWord  { get; set; }
}