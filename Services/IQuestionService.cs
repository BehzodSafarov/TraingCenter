using Backend.Enums;
using Backend.Models;

namespace Backend.Services;


public interface IQuestionService
{
    ValueTask<Result<Question>> CreateAsync(string title, Level level, string AOption, string BOption,
                                                         string COption, string DOption, string RightOption);
    ValueTask<Result> Remove(int id);
    ValueTask<Result<Question>> Update(int id, string title, Level level, string AOption, string BOption,
                                                         string COption, string DOption, string RightOption);
    ValueTask<Result<List<Question>>> GetAll(int page, int limit);
    ValueTask<Result<Question>> GetById(int id);
    ValueTask<Result> RemoveAll();
}