using Backend.Models;

namespace Backend.Services;

public interface ITestService
{
    ValueTask<Result<List<QuestionBody>>> CreateTest(int level1, int lvel2, int level3);
    ValueTask<Result<List<TestAnswer>>> ValidateTestAnswers(List<TestAnswer> test);
}