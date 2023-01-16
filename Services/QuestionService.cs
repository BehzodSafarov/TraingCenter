using Backend.Enums;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public partial class QuestionService : IQuestionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(IUnitOfWork unitOfWork, ILogger<QuestionService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async ValueTask<Result<Question>> CreateAsync(string title, Level level, string AOption, string BOption,
                                                         string COption, string DOption, string RightOption)
    {
        try
        {
            if(string.IsNullOrEmpty(title)
            || string.IsNullOrEmpty(AOption)
            || string.IsNullOrEmpty(BOption)
            || string.IsNullOrEmpty(COption)
            || string.IsNullOrEmpty(DOption))
              return new("This properties can't be null or empty");

            var createdQuestion = await _unitOfWork.Questions!.AddAsync(ToEntityQuestion(title, level,AOption, BOption, COption, DOption,RightOption));

            return new(true) {Data = ToModelQuestion(createdQuestion)};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Question didn't created");
            throw new Exception(e.Message);
        }
    }

    
    public async ValueTask<Result<List<Question>>> GetAllWithPaginaton(int page, int limit)
    {
        try
        {
            if(page <= 0 || limit <= 0)
            return new("Page or limit can't be thero or minus");

            var existQuestions = _unitOfWork.Questions!.GetAll();

            if(existQuestions is null)
            return new("Questions not exist yet");

            var filteredQuestions = existQuestions
            .Skip((page-1)*limit)
            .Take(limit)
            .Select(x => ToModelQuestion(x))
            .ToList();

            return new(true) {Data = filteredQuestions};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Questions didn't get");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result> Remove(int id)
    {
        try
        {
            if(id <= 0)
            return new("Id can't be null or minus");
            
            var existQuestion = _unitOfWork.Questions!.GetById(id);

            if(existQuestion is null)
            return new("This question didn't found");

            var removed = _unitOfWork.Questions.Remove(existQuestion);

            return new(true);
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Question didn't removed");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result> RemoveAll()
    {
        try
        {
            var questions = _unitOfWork.Questions!.GetAll();

            if(questions is null)
            return new("Questions not exist");

            var removedQuestions = _unitOfWork.Questions.RemoveRange(questions);

            return new(true);
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Questions didn't removed");
            throw new Exception(e.Message);
        }
    }

    public async ValueTask<Result<Question>> Update(int id, string title, Level level, string AOption, string BOption,
                                                         string COption, string DOption, string RightOption)
    {
        try
        {
            if(id <= 0)
            return new("Id cant be thero  or minus");

            var question = _unitOfWork.Questions!.GetById(id);
            
            if(question is null)
            return new("This question is not exist");

            var updatedQuestion = await _unitOfWork.Questions.Update(UpdateQuestion(question, title,  level,  AOption,  BOption,
                                                          COption,  DOption,  RightOption));

            return new(true) {Data = ToModelQuestion(updatedQuestion)};
        }
        catch (System.Exception e)
        {
            _logger.LogInformation("Questions didn't updated");
            throw new Exception(e.Message);
        }
    }

    

    public async ValueTask<Result<Question>> GetById(int id)
    {
        if(id <= 0)
        return new("id can't be Thero or minus");

        var question = _unitOfWork.Questions!.GetById(id);
        
        if(question is null)
        return new("Question not Found");

        return new(true) {Data = ToModelQuestion(question)};
    }

    public async ValueTask<Result<List<Question>>> GetAll()
    {
       try
       {
         var existQuestions = _unitOfWork.Questions.GetAll();

         if(existQuestions is null)
         return new("Questions is not exist");

         return new(true) {Data = existQuestions.Select(x => ToModelQuestion(x)).ToList()};
       }
       catch (System.Exception e)
       {
        _logger.LogInformation("Questions didn't taked");
        throw new Exception(e.Message);
       }
    }
}