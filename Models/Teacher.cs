using Backend.Enums;

namespace Backend.Models;

public class Teacher
{
    public  int Id { get; set; }
    public  string? UserName { get; set;}
    public  string? Email { get; set; }
    public  string? PhoneNumber { get; set; }
    public int? Age {get; set;} 
    public long Salary {get; set;} 
    public Gender? Gender {get; set;}
    public DateOnly FirstWork {get; set;}
    public DateOnly LastTakeSalary {get; set;} 
    public long LastTakeMoney {get; set;}
    public bool Debt {get; set;} = true;
    public int? Experience {get; set;} 
    // public virtual List<StudentTeacher>? StudentTeachers {get; set;}
}