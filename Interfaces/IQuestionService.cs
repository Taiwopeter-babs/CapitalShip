using CapitalShip.Dtos;
using CapitalShip.Utilities;

namespace CapitalShip.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> AddQuestionAsync(QuestionCreateDto question);
    Task UpdateQuestionAsync(string questionId, QuestionUpdateDto question);

    Task<QuestionDto> GetQuestionAsync(string questionId);

    Task<IEnumerable<QuestionDto>> GetManyQuestionsAsync(QuestionParameters questionParams);
    Task DeleteQuestionAsync(string questionId);
}