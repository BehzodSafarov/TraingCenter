using Backend.Data;
using Backend.Entities;

namespace Backend.Repositories;

public class StudentTeacherRepository : GenericRepository<StudentTeacher>, IStudentTeacherRepository
{
    public StudentTeacherRepository(AppDbContext context) : base(context)
    {
    }
}