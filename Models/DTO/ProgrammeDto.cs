namespace CapitalShip.Dtos;


public record ProgrammeCreateDto : BaseCandidateDto
{
    public List<QuestionDto>? Questions { get; init; }
}

public record ProgrammeDto : BaseCandidateDto
{
    public List<QuestionDto>? Questions { get; init; }
}