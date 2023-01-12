
using Backend.Enums;
using Backend.Models;

namespace Backend.Services;

public  partial class StudentService
{
    private static Student ToModel(Entities.Student createdStudent)
    {
        return new Student()
        {
            Id = createdStudent.Id,
            Age = createdStudent.Age,
            UserName = createdStudent.UserName,
            PhoneNumber = createdStudent.PhoneNumber,
            Email = createdStudent.Email,
            FirstLesson = createdStudent.FirstLesson,
            Debt = createdStudent.Debt,
            LastPay = createdStudent.LastPay,
            Gender = createdStudent.Gender
        
        };
    }

    private static Entities.Student ToEntity(string name, string email, string phoneNumber, int age, Gender gender)
    {
        return new Entities.Student
        {
         UserName = name,
         Email = email,
         PhoneNumber = phoneNumber,
         Age = age,
         Gender = gender,
        };
    }
    private static Entities.Student ToEntityUpdateStudent(Entities.Student student, string name, string email, string phoneNumber, int age, Gender gender)
    {
        student.Age = age;
        student.UserName = name;
        student.Email = email;
        student.PhoneNumber = phoneNumber;
        student.Gender = gender;

        return student;
    }

    private static Teacher ToModelTeacher(Entities.Teacher? teacher)
    => new()
    {
       Id = teacher.Id,
       UserName = teacher.UserName,
       Email = teacher.Email,
       PhoneNumber = teacher.PhoneNumber,
       Age = teacher.Age,
       Salary = teacher.Salary,
       Gender = teacher.Gender,
       FirstWork = teacher.FirstWork,
       LastTakeMoney = teacher.LastTakeMoney,
       LastTakeSalary = teacher.LastTakeSalary,
       Debt = teacher.Debt,
       Experience = teacher.Experience,
    };

   
}