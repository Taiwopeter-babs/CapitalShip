using CapitalShip.Data;
using CapitalShip.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

public class CosmosDbService : ICosmosDbService
{
    private readonly CosmosClient _cosmosClient;
    private readonly IOptions<CosmosDbOptions> _cosmosDbOptions;

    public CosmosDbService(CosmosClient cosmosClient, IOptions<CosmosDbOptions> cosmosDbOptions)
    {
        _cosmosClient = cosmosClient;
        _cosmosDbOptions = cosmosDbOptions;
    }

    public async Task<Container> GetContainerAsync(string containerName)
    {
        string? cosmosDatabase = _cosmosDbOptions.Value.Database;

        Database database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(cosmosDatabase);
        await database.CreateContainerIfNotExistsAsync(containerName, "/id");

        return database.GetContainer(containerName);
    }
}
