using CapitalShip.Data;
using CapitalShip.Dtos;
using CapitalShip.Interfaces;
using CapitalShip.Services;
using CapitalShip.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;


namespace CapitalShip.Extensions;

public static class ServiceExtensions
{

    /// <summary>
    /// Register database context
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void ConfigureDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CosmosDbOptions>(configuration.GetSection("CosmosDb"));

        // string accountEndpoint =

        services.AddSingleton((provider) =>
        {

            var cosmos = configuration.GetSection("CosmosDb").Get<CosmosDbOptions>();

            // Console.WriteLine($"{cosmos?.AccountEndpoint} {cosmos?.AccountKey}");

            return new CosmosClient(cosmos?.AccountEndpoint, cosmos?.AccountKey);
        });

        services.AddScoped<ICosmosDbService, CosmosDbService>();
    }

    /// <summary>
	/// Configure cors for application
	/// </summary>
	/// <param name="services"></param>
	public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    /// <summary>
    /// Configure a scoped service manager dependency injection
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    /// <summary>
    /// Register validators
    /// </summary>
    /// <param name="services"></param>
    public static void ConfigureValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IValidator<QuestionCreateDto>, QuestionValidator>();
        services.AddScoped<IValidator<QuestionUpdateDto>, QuestionUpdateValidator>();
        services.AddScoped<IValidator<CandidateCreateDto>, CandidateValidator>();
    }

}