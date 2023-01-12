using Backend.Enums;
using Backend.Models;

namespace Backend.Services;

public interface IStudentService
{
    ValueTask<Result<Student>> CrateAsync(string name, string email, string phoneNumber, int age, Gender gender);
    ValueTask<Result> Remove(int id, string emile);
    ValueTask<Result<Student>> UpdateAsync(string previousEmail, string name, string email, string phoneNumber, int age, Gender gender);
    ValueTask<Result<List<Student>>> GetAllAsync(int page, int limit);
    ValueTask<Result<Student>> GetOneStudent(string name, string email);
    ValueTask<Result<List<Student>>> GetByNameStudents(string name);
    ValueTask<Result<List<Teacher>>> GetTeachersWithStudent(int id);
    ValueTask<Result<Entities.StudentTeacher>> AddToTeacher(int teacherId, int studentId);

}