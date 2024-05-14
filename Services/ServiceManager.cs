using AutoMapper;
using CapitalShip.Data;
using CapitalShip.Interfaces;
using Microsoft.Extensions.Options;

namespace CapitalShip.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IQuestionService> _questionService;
    private readonly Lazy<ICandidateService> _candidateService;


    public ServiceManager(ICosmosDbService cosmosDbService, IMapper mapper, IOptions<CosmosDbOptions> cosmosDbOptions)
    {
        _questionService = new Lazy<IQuestionService>(() => new QuestionService(cosmosDbService, mapper, cosmosDbOptions));
        _candidateService = new Lazy<ICandidateService>(() => new CandidateService(cosmosDbService, mapper, cosmosDbOptions));

    }

    public IQuestionService QuestionService => _questionService.Value;

    public ICandidateService CandidateService => _candidateService.Value;

}