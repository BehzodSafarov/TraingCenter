using Backend.Data;

namespace Backend.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public ITeacherRepository? Teachers {get;}
    public IStudentRepository? Students {get;}
    public IStudentTeacherRepository? StudentTeachers {get;}

    public IQuestionRepository? Questions {get;}


    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        Teachers = new TeacherRepository(context);
        
        Students = new StudentRepository(context);
        StudentTeachers = new StudentTeacherRepository(context);
        Questions = new QuestionRepository(context);
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
    public int Save()
    => _context.SaveChanges();
    
}