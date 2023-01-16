using Backend.Enums;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public partial  class TeacherService : ITeacherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public TeacherService(IUnitOfWork unitOfWork, ILogger<TeacherService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async ValueTask<Result<Teacher>> CrateAsync(string name, string email, string phoneNumber, int age, Gender gender, long salary,int experience)
    {
        try
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || 
              string.IsNullOrEmpty(phoneNumber) || age < 0)
              {
                return new("invalid parametr");
              }

            var createdTeacher = await _unitOfWork.Teachers!.AddAsync(ToEntity(name,email,phoneNumber,age,gender,salary,experience));

            if(createdTeacher is null)
            return new("teacher can't created");

            
            return new(true) {Data = ToModel(createdTeacher)};

        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"teacher is not crated Name: {name}");

            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Teacher>>> GetAllAsync()
    {
        try
        {
            var teachers = _unitOfWork.Teachers.GetAll();

            if(teachers is null)
            return new("Teachers is not exist");

            return new(true) {Data = teachers.Select(x => ToModel(x)).ToList()};
        }
        catch (System.Exception e)
        {
            
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Teacher>>> GetAllWithPaginationAsync(int page=1, int limit=100)
    {
        try
        {
            var existTeachers = _unitOfWork.Teachers.GetAll();
            System.Console.WriteLine("=====================>");
            if(existTeachers is null)
            return new("Teachers is null here");
            var allTeachers = existTeachers
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(e => ToModel(e))
                .ToList();

            if(allTeachers is null)
            return new("teachers are not found");


            return new(true) {Data = allTeachers};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"teachers not taked");   
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Teacher>>> GetByNameTeachers(string name)
    {
        try
        {
            var teachers =  _unitOfWork.Teachers!.GetAll().Where(x => x.UserName == name);

            if(teachers is null)
            return new("teacher not found");

            return new(true) {Data = teachers.Select(x => ToModel(x)).ToList()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"teachers can't taked");
            throw new Exception(e.Message);
        }
    }

   

    public async ValueTask<Result<Teacher>> GetOneTeacher(string name, string email)
    {
        try
        {
            if(string.IsNullOrEmpty(name)
            ||string.IsNullOrEmpty(email))
            return new("name or email can't be null");

            var teacher = _unitOfWork.Teachers!.GetAll()
            .Where(x => x.UserName == name && x.Email == email).FirstOrDefault();

            if(teacher is null)
            return new("this teacher is not found");

            return new(true) {Data = ToModel(teacher)};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("this student is not found");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Student>>> GetStudentsWithTeacher(int id)
    {
        try
        {
            if(id <= 0)
            return new("Id can't be null here");

            var teacher = _unitOfWork.Teachers!.GetById(id);

            if(teacher is null)
            return new("teacher not exist");

            var students = _unitOfWork.StudentTeachers!.GetAll().Where(x => x.TeacherId == id);

            if(students is null)
            return new("teacher not found");
            
            
            return new(true) {Data = students.Select(x => ToModelStudent(x.Student)).ToList()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("This teacher's student not taked");
            throw new Exception(e.Message);
        }
    }

    

    public async ValueTask<Result> Remove(int id, string email)
    {
        try
        {
            if(id <= 0 || string.IsNullOrEmpty(email))
            return new("Id or email is empty");
            
            var teacher = _unitOfWork.Teachers!.Find(x => x.Id == id && 
            x.Email == email).FirstOrDefault();

            var removedStudent = _unitOfWork.Teachers.Remove(teacher!);

            return new(true);
        }
        catch (System.Exception e)
        {
            _logger.LogInformation(e.Message);
            throw new Exception(e.Message);
        }
    }


    public async ValueTask<Result<Teacher>> UpdateAsync(string previousEmail, string name, string email, string phoneNumber, int age, Gender gender, long salary, int experience)
    {
      try
      {
          if(string.IsNullOrEmpty(previousEmail))
          return new("previous emile is empty here");

          var teacher = _unitOfWork.Teachers!.Find(x => x.Email == previousEmail).FirstOrDefault();

          if(teacher is null)
          return new("this teacher email is not valid");

          var updatedTeacher = await _unitOfWork.Teachers
          .Update(ToEntityUpdatedTeacher(teacher, name, email, phoneNumber, age, gender, salary, experience));

          return new(true) {Data = ToModel(updatedTeacher)};
       }
      catch (System.Exception e)
      {
        _logger.LogInformation("Teacher is not updated");
        throw new Exception(e.Message);
      }
    }

    


}