using Backend.Entities;
using Backend.Enums;

namespace Backend.Services;

public partial class QuestionService
{
   private static Models.Question ToModelQuestion(Entities.Question question)
   => new()
    {
        Id = question.Id,
        Title = question.Title,
        Level = question.Level,
        AOption = question.AOption,
        BOption = question.BOption,
        COption = question.COption,
        DOption = question.DOption,
        RightOption = question.RightOption
    };

    private static Entities.Question ToEntityQuestion(string title, Level level, string aOption,
                 string bOption, string cOption, string dOption, string rightOption)
    => new()
    {
        Title = title,
        Level = level,
        AOption = aOption,
        BOption = bOption,
        COption = cOption,
        DOption = dOption,
        RightOption = rightOption
    };
   
    private Entities.Question UpdateQuestion(Entities.Question question,string title, Level level, string AOption, string BOption,
                                                         string COption, string DOption, string RightOption)
    {
        question.Title = title;
        question.Level = level;
        question.AOption = AOption;
        question.BOption = BOption;
        question.COption = COption;
        question.DOption = DOption;
        question.RightOption = RightOption;

        return question;
    }
}