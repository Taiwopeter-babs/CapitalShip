namespace CapitalShip.Dtos;

public record AnswerDto : BaseQuestionDto
{
    // public string? Id { get; set; }
    public string? QuestionAnswer { get; init; }
}