using Backend.Dtos;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller;
[ApiController]
[Route("api/[controller]")]

public class TestController : ControllerBase
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpPost("CreateTests")]
    public async Task<IActionResult> CreateTest(int level1, int level2, int level3)
    {
     if(level1 < 0 || level2 < 0 || level3 < 0)
     return BadRequest("Levels can't be minus ");

     var createdTest = await _testService.CreateTest(level1, level2, level3);

     return Ok(createdTest);
    }

    [HttpPost("ValidateTest")]
    public async Task<IActionResult> Validate(List<AnswerDto> answers)
    {
      if(answers is null)
      return BadRequest();
      var answerList = answers.Select(x => ToModel(x)).ToList();

      var validated = _testService.ValidateTestAnswers(answerList);

      return Ok(validated);
    }

    private TestAnswer ToModel(AnswerDto x)
    => new()
    {
        Id = x.Id,
        QuestinNumber = x.QuestinNumber,
        ChosedQuestion = x.ChosedQuestion
    };

}