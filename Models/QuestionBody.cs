using Backend.Enums;

namespace Backend.Models;

public class QuestionBody
{
    public int Id { get; set; }
    public Level Level { get; set; }
    public string? Title { get; set; }
    public int QuestionNumber { get; set; }
  
    public string? AOption { get; set; }
    public string? BOption { get; set; }
    public string? COption { get; set; }
    public string? DOption { get; set; }
}