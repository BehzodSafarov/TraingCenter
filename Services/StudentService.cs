using Backend.Enums;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public partial class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public StudentService(IUnitOfWork unitOfWork, ILogger<StudentService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async ValueTask<Result<Entities.StudentTeacher>> AddToTeacher(int teacherId, int studentId)
    {
        try
        {
            if(teacherId <= 0 || studentId <= 0)
            return new("Id cant't be minus or Thero");

            var studentTeacher = new Entities.StudentTeacher()
            {
                StudentId = studentId,
                TeacherId = teacherId
            };

            var addedStudentTeacher = await _unitOfWork.StudentTeachers!.AddAsync(studentTeacher);

            return new(true) {Data = addedStudentTeacher};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Can't add to teacher");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<Student>> CrateAsync(string name, string email, string phoneNumber, int age, Gender gender)
    {
        try
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || 
              string.IsNullOrEmpty(phoneNumber) || age < 0)
              {
                return new("invalid parametr");
              }

            var createdStudent = await _unitOfWork.Students!.AddAsync(ToEntity(name, email, phoneNumber, age, gender));

            if(createdStudent is null)
            return new("student can't created");

            
            return new(true) {Data = ToModel(createdStudent)};

        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"student is not crated Name: {name}");

            throw new Exception(e.Message);
        }
    }


    public async ValueTask<Result<List<Student>>> GetAllAsync(int page=0, int limit=10)
    {
        try
        {
            var existStudents = _unitOfWork.Students!.GetAll();
            if(existStudents is null)

            return new("Students not found");

            var allStudents = existStudents
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(e => ToModel(e))
                .ToList();

            if(allStudents is null)
            return new("Students are not found");


            return new(true) {Data = allStudents};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Studnts not taced");   
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Student>>> GetByNameStudents(string name)
    {
        try
        {
            var students =  _unitOfWork.Students!.GetAll().Where(x => x.UserName == name);

            if(students is null)
            return new("student not found");

            return new(true) {Data = students.Select(x => ToModel(x)).ToList()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Students can't taked");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<Student>> GetOneStudent(string name, string email)
    {
        try
        {
            if(string.IsNullOrEmpty(name)
            ||string.IsNullOrEmpty(email))
            return new("name or email can't be null");

            var student = _unitOfWork.Students!.GetAll()
            .Where(x => x.UserName == name && x.Email == email).FirstOrDefault();

            if(student is null)
            return new("this student is not found");

            return new(true) {Data = ToModel(student)};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("this student is not found");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<Teacher>>> GetTeachersWithStudent(int id)
    {
        try
        {
            if(id <= 0)
            return new("Id can't be null here");

            var student = _unitOfWork.Students!.GetById(id);

            if(student is null)
            return new("student not exist");

            var teachers = _unitOfWork.StudentTeachers!.GetAll().Where(x => x.StudentId == id);

            if(teachers is null)
            return new("teacher not found");

            
            return new(true) {Data = teachers.Select(x => ToModelTeacher(x.Teacher)).ToList()};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("This student's teacher not taked");
            throw new Exception(e.Message);
        }
    }

   

    public async ValueTask<Result> Remove(int id, string email)
    {
        try
        {
            if(id <= 0 || string.IsNullOrEmpty(email))
            return new("Id or email is empty");
            
            var student = _unitOfWork.Students!.Find(x => x.Id == id && 
            x.Email == email).FirstOrDefault();

            var removedStudent = _unitOfWork.Students.Remove(student!);

            return new(true);
        }
        catch (System.Exception e)
        {
            _logger.LogInformation(e.Message);
            throw new Exception(e.Message);
        }
    }


    public async ValueTask<Result<Student>> UpdateAsync(string previousEmail, string name, string email, string phoneNumber, int age, Gender gender)
    {
      try
      {
          if(string.IsNullOrEmpty(previousEmail))
          return new("previous emile is empty here");

          var student = _unitOfWork.Students!.Find(x => x.Email == previousEmail).FirstOrDefault();

          if(student is null)
          return new("this student email is not valid");

          var updatedStudent = await _unitOfWork.Students
          .Update(ToEntityUpdateStudent(student, name, email, phoneNumber, age, gender));

          return new(true) {Data = ToModel(updatedStudent)};
       }
      catch (System.Exception e)
      {
        _logger.LogInformation("Student is not updated");
        throw new Exception(e.Message);
      }
    }

    
}