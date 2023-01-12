using Backend.Enums;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities;

public class Teacher
{
    public  int Id { get; set; }
    public  string? UserName { get; set;}
    public  string? Email { get; set; }
    public  string? PhoneNumber { get; set; }
    public int? Age {get; set;} 
    public long Salary {get; set;} 
    public Gender? Gender {get; set;}
    public DateTime FirstWork {get; set;}
    public DateTime LastTakeSalary {get; set;} 
    public long LastTakeMoney {get; set;}
    public bool Debt {get; set;} = true;
    public int? Experience {get; set;} 
    public virtual List<StudentTeacher>? StudentTeachers {get; set;}

    public Teacher()
    {}

    // public Teacher(string userName,
    // string email, string phoneNumber, 
    // string passwordHash,int experience,
    // int age, Gender gender,long salary,
    // DateTime firstWork,DateTime lastTakeSalary,
    // long lastTakeMoney,bool debt)
    // {
    //     this.UserName = userName;
    //     this.Email = email;
    //     this.PhoneNumber = phoneNumber;
    //     this.Experience = experience;
    //     this.Age = age;
    //     this.Gender = gender;
    //     this.Salary = salary;
    //     this.LastTakeSalary = lastTakeSalary;
    //     this.FirstWork = firstWork;
    //     this.LastTakeMoney = lastTakeMoney;
    //     this.Debt = debt;
    // }
}