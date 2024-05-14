using AutoMapper;
using BookARoom.Extensions;
using CapitalShip.Data;
using CapitalShip.Dtos;
using CapitalShip.Exceptions;
using CapitalShip.Interfaces;
using CapitalShip.Models;
using CapitalShip.Utilities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Options;


namespace CapitalShip.Services;

public class CandidateService : ICandidateService
{
    private readonly ICosmosDbService _cosmosDbService;
    private readonly IMapper _mapper;
    private readonly IOptions<CosmosDbOptions> _cosmosDbOptions;

    public CandidateService(ICosmosDbService cosmosDbService, IMapper mapper, IOptions<CosmosDbOptions> cosmosDbOptions)
    {
        _cosmosDbService = cosmosDbService;
        _mapper = mapper;
        _cosmosDbOptions = cosmosDbOptions;

    }


    public async Task<CandidateDto> AddCandidateAsync(CandidateCreateDto candidateCreationDto)
    {
        var candidate = _mapper.Map<Candidate>(candidateCreationDto);

        Container container = await GetContainerAsync();

        var candidateEntity = await container.CreateItemAsync(candidate);

        var resource = candidateEntity.Resource;

        return _mapper.Map<CandidateDto>(resource);
    }

    public async Task<CandidateDto> GetCandidateAsync(string candidateId)
    {
        var candidate = await CheckCandidate(candidateId);

        return _mapper.Map<CandidateDto>(candidate);
    }


    public async Task DeleteCandidateAsync(string candidateId)
    {
        await CheckCandidate(candidateId);

        Container container = await GetContainerAsync();

        await container.DeleteItemAsync<Candidate>(candidateId, new PartitionKey(candidateId));
    }

    // public async Task UpdateQuestionAsync(string questionId, QuestionUpdateDto questionUpdateDto)
    // {
    //     Container container = await GetContainerAsync();

    //     var question = await CheckQuestion(questionId);

    //     _mapper.Map(questionUpdateDto, question);


    //     await container.UpsertItemAsync(question);

    // }

    public async Task<IEnumerable<CandidateDto>> GetManyCandidatesAsync()
    {
        Container container = await GetContainerAsync();

        using FeedIterator<Candidate> setIterator = container.GetItemLinqQueryable<Candidate>()
            .OrderBy(c => c.FirstName)
            .ThenBy(c => c.LastName)
            .ToFeedIterator();

        List<Candidate> results = [];

        //Asynchronous query execution
        while (setIterator.HasMoreResults)
        {
            var response = await setIterator.ReadNextAsync();

            results.AddRange(response.ToList());
        }

        return _mapper.Map<IEnumerable<CandidateDto>>(results);
    }

    private async Task<Candidate> CheckCandidate(string candidateId)
    {
        ItemResponse<Candidate> candidate;

        Container container = await GetContainerAsync();

        try
        {
            candidate = await container.ReadItemAsync<Candidate>(candidateId, new PartitionKey(candidateId));

            return candidate.Resource;
        }
        catch (CosmosException)
        {
            throw new CandidateNotFoundException(candidateId);
        }
    }

    private async Task<Container> GetContainerAsync()
    {
        string? containerName = _cosmosDbOptions.Value.CandidateContainer;

        return await _cosmosDbService.GetContainerAsync(containerName!);
    }
}