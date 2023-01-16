using Backend.Enums;

namespace Backend.Services;

public partial class TeacherService
{
   private static Models.Teacher ToModel(Entities.Teacher teacher)
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
       LastTakeMoney =  teacher.LastTakeMoney,
       LastTakeSalary = teacher.LastTakeSalary,
       Debt = teacher.Debt,
       Experience = teacher.Experience,
    };
    private static Models.Student ToModelStudent(Entities.Student? student)
    => new()
    {
            Id = student.Id,
            Age = student.Age,
            UserName = student.UserName,
            PhoneNumber = student.PhoneNumber,
            Email = student.Email,
            FirstLesson = student.FirstLesson,
            Debt = student.Debt,
            LastPay = student.LastPay,
            Gender = student.Gender
    };
    private static Entities.Teacher ToEntityUpdatedTeacher(Entities.Teacher teacher, string name, string email, string phoneNumber, int age, Gender gender, long salary, int experience)
    {
        teacher.UserName = name;
        teacher.Email = email;
        teacher.PhoneNumber = phoneNumber;
        teacher.Age = age;
        teacher.Gender = gender;
        teacher.Salary = salary;
        teacher.Experience = experience;
        
        return teacher;
    }

    private static Entities.Teacher ToEntity(string name, string email, string phoneNumber, 
    int age, Gender gender, long salary, int experience)
    => new()
    {
       UserName = name,
       Email = email,
       PhoneNumber = phoneNumber,
       Age = age,
       Salary = salary,
       Gender = gender,
       Experience = experience,
    };
}