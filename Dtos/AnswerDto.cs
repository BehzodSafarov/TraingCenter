using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos;

public class AnswerDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int QuestinNumber { get; set; }
    [Required]
    public string? ChosedQuestion { get; set; }

}