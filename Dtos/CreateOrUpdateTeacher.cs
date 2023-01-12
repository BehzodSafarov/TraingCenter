using Backend.Enums;

namespace Backend.Dtos;

public class CreateOrUpdateTeacher
{
    public  string? UserName { get; set;}
    public  string? Email { get; set; }
    public  string? PhoneNumber { get; set; }
    public int Age {get; set;} 
    public long Salary {get; set;} 
    public Gender Gender {get; set;}
    public int Experience {get; set;} 
}