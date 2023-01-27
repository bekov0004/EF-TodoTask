namespace Domain.Dtos;

public class AddTask
{
    public int  id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime timestamps { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int CategoryId { get; set; }
}