namespace CapitalShip.Dtos;

public record CandidateCreateDto : BaseCandidateDto
{
    // public int ProgramId { get; init; }
    public List<AnswerDto>? Answers { get; init; }
}

public record CandidateDto : BaseCandidateDto
{
    // public int ProgramId { get; init; }
    public string? Id { get; init; }
    public List<AnswerDto>? Answers { get; init; }
}