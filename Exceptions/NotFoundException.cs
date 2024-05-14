namespace CapitalShip.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}

public sealed class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException(string questionId) :
            base($"The question with the id: {questionId} was not found")
    {
    }
}

public sealed class CandidateNotFoundException : NotFoundException
{
    public CandidateNotFoundException(string candidateId) :
        base($"The candidate with the id: {candidateId} was not found")
    {
    }
}