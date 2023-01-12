    using Backend.Dtos;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace Backend.Controller;
    [ApiController]
    [Route("api/[controller]")]

    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService service)
        {
            _studentService = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatOrUpdateStudent student)
        {
            var createdTeacher = await _studentService
                                .CrateAsync(student.UserName!,student.Email!,
                                student.PhoneNumber!, student.Age, student.Gender);

            return Ok(createdTeacher);
        }

        [HttpDelete("Delete")]
        public  async Task<IActionResult> Remove(int id, string email)
        {
            return Ok(await _studentService.Remove(id, email));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CreatOrUpdateStudent student, string previousEmail)
        {
            var updatedStudent = await _studentService.UpdateAsync( previousEmail, student.UserName!,student.Email!,
                                student.PhoneNumber!, student.Age, student.Gender);

            return Ok(updatedStudent);
        }
      
      [HttpGet("GetWithPagination")]
      public async Task<IActionResult> GetAll(int page, int limit) 
      {
        if(page < 0 || limit < 0)
        return BadRequest("Page or Limit is minus");

        return Ok(await _studentService.GetAllAsync(page, limit));
      }
      
      [HttpGet("GetOne")]
      public async Task<IActionResult> GetOnTeacher(string name, string email)
      {
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        return BadRequest("Name or Email is Null or empty there");
        var student = await _studentService.GetOneStudent(name, email);

        return Ok(student);
      }
     
      [HttpGet("GetWithName")]
      public async Task<IActionResult> GetByName(string name)
      {
        if(string.IsNullOrEmpty(name))
        return BadRequest("Name is null or empty");

        var teachers = await _studentService.GetByNameStudents(name);

        return Ok(teachers);
      }
      
      [HttpGet("GetTeachersWithStudentId")]
      public async Task<IActionResult> GetTeachersWithStudent(int id)
      {
        if(id <= 0)
        return BadRequest("Id Minus or thero");

        var students = await _studentService.GetTeachersWithStudent(id);

        return Ok(students);
      }

      [HttpPost("AddToTeacher")]
      public async Task<IActionResult> AddToTeacher(int teacherId, int studentId)
      {
       if(teacherId <= 0 || studentId <= 0)
       return BadRequest("Id cant't be null");
       
       var addedStudentTeacher = await _studentService.AddToTeacher(teacherId, studentId);
       return Ok();
      }
    }