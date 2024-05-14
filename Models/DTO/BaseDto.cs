namespace CapitalShip.Dtos;

public record BaseCandidateDto
{
    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? Email { get; init; }

    public string? Phone { get; init; }

    public string? Nationality { get; init; }

    public string? CurrentResidence { get; init; }

    public int IdNumber { get; init; }

    public DateTime Birthday { get; init; }

    public string? Gender { get; init; }
}

public record BaseQuestionDto
{
    /// <summary>
    /// This property adheres to the QuestionType enum.
    /// The enum is used to validate the DTO with fluent validation
    /// </summary>
    public string? QuestionType { get; init; }

    public string? QuestionTitle { get; init; }
}
