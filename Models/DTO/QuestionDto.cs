namespace CapitalShip.Dtos;

public record QuestionDto : BaseQuestionDto
{
    public string? Id { get; set; }
}

public record QuestionCreateDto : BaseQuestionDto
{
}

public record QuestionUpdateDto : BaseQuestionDto
{
}