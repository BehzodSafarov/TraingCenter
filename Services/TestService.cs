using Backend.Enums;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;


public class TestService : ITestService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TestService> _logger;

    public TestService(IUnitOfWork unitOfWork, ILogger<TestService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async ValueTask<Result<List<QuestionBody>>> CreateTest(int level1, int level2, int level3)
    {
        try
        {
           var allQuestions = _unitOfWork.Questions!.GetAll().ToList();
           if(allQuestions is null)
           return new("Questions is not exist yet");
        
           var resultQuestions = new List<QuestionBody>();

           resultQuestions.AddRange(ChoseRandomQuestionWithLevel(Level.Beginner,level1,allQuestions).ToList());
           resultQuestions.AddRange(ChoseRandomQuestionWithLevel(Level.Intermediate,level2,allQuestions));
           resultQuestions.AddRange(ChoseRandomQuestionWithLevel(Level.Advnced,level3,allQuestions));
           
           int questionNumber = 0;
           foreach (var item in resultQuestions)
           {
             questionNumber += 1;
             item.QuestionNumber = questionNumber;
           }
           return new(true) {Data = resultQuestions};
        }
        catch (System.Exception e)
        {
            
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<List<TestAnswer>>> ValidateTestAnswers(List<TestAnswer> test)
    {
        try
        {
            if(test is null)
            return new("test can't be null");

            var testAnswers = test.Select(x => Validate(x)).ToList();

            return new(true) {Data = testAnswers};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Tests can't validated");
            throw new Exception(e.Message);
        }
    }

    private List<QuestionBody> ChoseRandomQuestionWithLevel(Level level, int count, List<Entities.Question> questions)
    {
      var filteredQuestions = questions.Where(x => x.Level == level).ToList();

      if(filteredQuestions.Count() < count)
      count = filteredQuestions.Count();

      List<int> list = new List<int>();

     filteredQuestions.ForEach(x => list.Add(x.Id));

     var random = new Random();

     var resultQuestions = filteredQuestions.OrderBy(x => random.Next()).Take(count);

     return resultQuestions.Select(x => QuestionToQuestionBody(x)).ToList();

    }

    private TestAnswer Validate(TestAnswer testAnswer)
    {
        var question = _unitOfWork.Questions!.GetById(testAnswer.Id);
        
        if(question is null)
        return null;
        
        if(question.RightOption!.Equals(testAnswer.ChosedQuestion))
        {
            testAnswer.AnswerStatus = true;
        }
        else
        {
            testAnswer.AnswerStatus = false;
        }
        
        return testAnswer;
    }

    private QuestionBody QuestionToQuestionBody(Entities.Question x)
    => new()
    {
       Level = x.Level,
       Title = x.Title,
       AOption = x.AOption,
       BOption = x.BOption,
       COption = x.COption,
       DOption = x.COption,
       Id = x.Id
    };

}