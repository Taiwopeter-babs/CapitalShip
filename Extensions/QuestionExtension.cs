using CapitalShip.Models;

namespace BookARoom.Extensions;

public static class RoomRepositoryExtension
{



    public static IQueryable<Question> FilterQuestionsByType(this IQueryable<Question> questions,
        string? questionType)
    {
        return string.IsNullOrWhiteSpace(questionType) ? questions :
            questions.Where(q => q.QuestionType!.Equals(questionType, StringComparison.OrdinalIgnoreCase));
    }
}