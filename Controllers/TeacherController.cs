    using Backend.Dtos;
    using Backend.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace Backend.Controller;
    [ApiController]
    [Route("api/[controller]")]

    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService service)
        {
            _teacherService = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrUpdateTeacher teacher)
        {
            var createdTeacher = await _teacherService
                                .CrateAsync(teacher.UserName!,teacher.Email!,
                                teacher.PhoneNumber!, teacher.Age, teacher.Gender,
                                teacher.Salary,teacher.Experience );

            return Ok(createdTeacher);
        }

        [HttpDelete("Delete")]
        public  async Task<IActionResult> Remove(int id, string email)
        {
            return Ok(await _teacherService.Remove(id, email));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CreateOrUpdateTeacher teacher, string previousEmail)
        {
            var updatedTeacher = await _teacherService.UpdateAsync(previousEmail, teacher.UserName!,teacher.Email!,
                                teacher.PhoneNumber!, teacher.Age, teacher.Gender,
                                teacher.Salary,teacher.Experience);

            return Ok(updatedTeacher);
        }
      
      [HttpGet("GetWithPagination")]
      public async Task<IActionResult> GetAll(int page, int limit) 
      {
        if(page < 0 || limit < 0)
        return BadRequest("Page or Limit is minus");

        return Ok(await _teacherService.GetAllAsync(page, limit));
      }
      
      [HttpGet("GetOne")]
      public async Task<IActionResult> GetOnTeacher(string name, string email)
      {
        if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
        return BadRequest("Name or Email is Null or empty there");
        var teacher = await _teacherService.GetOneTeacher(name, email);

        return Ok(teacher);
      }
     
      [HttpGet("GetWithName")]
      public async Task<IActionResult> GetByName(string name)
      {
        if(string.IsNullOrEmpty(name))
        return BadRequest("Name is null or empty");

        var teachers = await _teacherService.GetByNameTeachers(name);

        return Ok(teachers);
      }
      
      [HttpGet("GetWithStudentsWithTeacherId")]
      public async Task<IActionResult> GetStudentsWithTeacher(int id)
      {
        if(id <= 0)
        return BadRequest("Id Minus or thero");

        var students = await _teacherService.GetStudentsWithTeacher(id);

        return Ok(students);
      }
    }