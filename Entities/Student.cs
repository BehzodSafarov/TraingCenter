using System.ComponentModel.DataAnnotations;
using Backend.Enums;
using Microsoft.AspNetCore.Identity;

namespace Backend.Entities;

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

    public virtual List<StudentTeacher>? StudentTeachers {get; set;}

    public Student()
    {
    }

    // public Student(
    // string email, string phoneNumber,
    // string userName,int age,
    // string gender, bool debt,
    // DateTime lastPay, DateTime firstLesson)
    // {
    //     this.UserName = userName;
    //     this.Email = email;
    //     this.PhoneNumber = phoneNumber;
    //     this.Age = age;
    //     this.Gender = gender;
    //     this.LastPay = lastPay;
    //     this.FirstLesson = firstLesson;
    //     this.Debt = debt;
    // }

}