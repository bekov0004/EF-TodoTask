using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string Name { get; set; }
}