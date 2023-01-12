using Backend.Enums;
using Backend.Models;

namespace Backend.Services;

public interface ITeacherService
{
    ValueTask<Result<Teacher>> CrateAsync(string name, string email, string phoneNumber, int age, Gender gender, long salary, int experience);
    ValueTask<Result> Remove(int id, string emile);
    ValueTask<Result<Teacher>> UpdateAsync(string previousEmail, string name, string email, string phoneNumber, int age, Gender gender, long salary, int experience);
    ValueTask<Result<List<Teacher>>> GetAllAsync(int page, int limit);
    ValueTask<Result<Teacher>> GetOneTeacher(string name, string email);
    ValueTask<Result<List<Teacher>>> GetByNameTeachers(string name);
    ValueTask<Result<List<Student>>> GetStudentsWithTeacher(int id);
}