using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Name { get; set; }
    [Required,MaxLength(70),]
    public string Email { get; set; }
    [Required,MaxLength(20)]
    public string Phone { get; set; }
    [Required,MinLength(5,ErrorMessage = "Minimum value 5 characters"),MaxLength(30,ErrorMessage = "Maximum value 25 characters")]
    public string PassWord  { get; set; }
    public List<Comment> Comments { get; set; }
}