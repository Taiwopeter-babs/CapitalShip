using Microsoft.Azure.Cosmos;

namespace CapitalShip.Interfaces;

public interface ICosmosDbService
{
    Task<Container> GetContainerAsync(string containerName);
}