namespace Backend.Repositories;

public interface IUnitOfWork
{
  public ITeacherRepository? Teachers {get;}
  public IStudentRepository? Students {get;}
  public IQuestionRepository? Questions {get;}

  public IStudentTeacherRepository? StudentTeachers {get;}
  int Save(); 
}