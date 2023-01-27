using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.Dtos;

public class CommentDto
{
    public int Id { get; set; }   
    [Required(ErrorMessage = "This field is required")]
    public int TodoTaskId{ get; set; } 
    [Required(ErrorMessage = "This field is required")]
    public string UserName { get; set; } 
    public string CommentText { get; set; }
}