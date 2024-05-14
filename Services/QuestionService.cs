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

public class QuestionService : IQuestionService
{
    private readonly ICosmosDbService _cosmosDbService;
    private readonly IMapper _mapper;
    private readonly IOptions<CosmosDbOptions> _cosmosDbOptions;

    public QuestionService(ICosmosDbService cosmosDbService, IMapper mapper, IOptions<CosmosDbOptions> cosmosDbOptions)
    {
        _cosmosDbService = cosmosDbService;
        _mapper = mapper;
        _cosmosDbOptions = cosmosDbOptions;

    }


    public async Task<QuestionDto> AddQuestionAsync(QuestionCreateDto questionCreationDto)
    {
        var question = _mapper.Map<Question>(questionCreationDto);

        Container container = await GetContainerAsync();

        var questionEntity = await container.CreateItemAsync(question);

        var resource = questionEntity.Resource;

        return _mapper.Map<QuestionDto>(resource);
    }

    public async Task<QuestionDto> GetQuestionAsync(string questionId)
    {
        var question = await CheckQuestion(questionId);

        return _mapper.Map<QuestionDto>(question);
    }


    public async Task DeleteQuestionAsync(string questionId)
    {
        await CheckQuestion(questionId);

        Container container = await GetContainerAsync();

        await container.DeleteItemAsync<Question>(questionId, new PartitionKey(questionId));
    }

    public async Task UpdateQuestionAsync(string questionId, QuestionUpdateDto questionUpdateDto)
    {
        Container container = await GetContainerAsync();

        var question = await CheckQuestion(questionId);

        _mapper.Map(questionUpdateDto, question);


        await container.UpsertItemAsync(question);

    }

    public async Task<IEnumerable<QuestionDto>> GetManyQuestionsAsync(QuestionParameters questionParams)
    {
        Container container = await GetContainerAsync();

        using FeedIterator<Question> setIterator = container.GetItemLinqQueryable<Question>()
            .FilterQuestionsByType(questionParams.QuestionType)
            .ToFeedIterator();

        List<Question> results = [];

        //Asynchronous query execution
        while (setIterator.HasMoreResults)
        {
            var response = await setIterator.ReadNextAsync();

            results.AddRange(response.ToList());
        }

        return _mapper.Map<IEnumerable<QuestionDto>>(results);
    }

    private async Task<Question> CheckQuestion(string questionId)
    {
        ItemResponse<Question> question;

        Container container = await GetContainerAsync();

        try
        {
            question = await container.ReadItemAsync<Question>(questionId, new PartitionKey(questionId));

            return question.Resource;
        }
        catch (CosmosException)
        {
            throw new QuestionNotFoundException(questionId);
        }
    }

    private async Task<Container> GetContainerAsync()
    {
        string? containerName = _cosmosDbOptions.Value.QuestionContainer;

        return await _cosmosDbService.GetContainerAsync(containerName!);
    }
}