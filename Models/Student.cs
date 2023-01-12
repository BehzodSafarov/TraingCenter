using Backend.Enums;

namespace Backend.Models;

public class Student
{
    public  int Id {get; set; }
    public  string? UserName { get; set; }
    public  string? Email { get; set; }
    public  string? PhoneNumber { get; set; }
    public int? Age {get; set;}
    public DateTime FirstLesson {get; set;}
    public DateTime LastPay {get; set;}
    public bool Debt {get; set;} = true;
    public Gender? Gender {get; set;}
}