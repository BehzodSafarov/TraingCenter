namespace Backend.Models;

public class TestAnswer
{
    public int Id { get; set; }
    public int QuestinNumber { get; set; }
    public string? ChosedQuestion { get; set; }
    public bool AnswerStatus { get; set; } = false;
    public string? RightOption { get; set; }
}