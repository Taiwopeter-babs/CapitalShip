namespace CapitalShip.Interfaces;

public interface IServiceManager
{
    IQuestionService QuestionService { get; }
    ICandidateService CandidateService { get; }
}