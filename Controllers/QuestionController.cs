using Backend.Dtos;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;

[ApiController]
[Route("api/[controller]")]

public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateOrUpdateQuestion question)
    {
       var createdQuestion = await _questionService
                            .CreateAsync(question.Title!, question.Level, question.AOption!,
                             question.BOption!, question.COption!, question.DOption!, question.RightOption!);

       return Ok(createdQuestion);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetQuestion(int id)
    {
        if(id <= 0)
        return BadRequest("Id cant be Thero or minus");

        var question = await _questionService.GetById(id);

        return Ok(question);
    }

    [HttpGet("GetAllWithPagination")]
    public async Task<IActionResult> GetAllQuestions(int page, int limit)
    {

        if(page <= 0 || limit <= 0)
        return BadRequest("Page or limit can't be Minus or Thero");

        return Ok(await _questionService.GetAllWithPaginaton(page, limit));

    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _questionService.GetAll());
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove(int id)
    {
        if(id <= 0)
        return BadRequest("Id can't be Thero or Minus");

        return Ok(await _questionService.Remove(id));
    }

    [HttpDelete("RemoveAll")]
    public async Task<IActionResult> RemoveAll()
    {
        return Ok(await _questionService.RemoveAll());
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CreateOrUpdateQuestion question, int id)
    {
        var updatedQuestion = await _questionService.Update(id, question.Title!, question.Level, question.AOption!,
                             question.BOption!, question.COption!, question.DOption!, question.RightOption!);

        return Ok(updatedQuestion);
    }
}