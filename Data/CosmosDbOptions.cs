using System.ComponentModel.DataAnnotations;

namespace CapitalShip.Data;

public sealed class CosmosDbOptions
{
    [Required]
    public string AccountEndpoint { get; set; } = null!;

    [Required]
    public string? AccountKey { get; set; } = null!;

    [Required]
    public string? Database { get; set; } = null!;

    [Required]
    public string? QuestionContainer { get; set; } = null!;

    [Required]
    public string? CandidateContainer { get; set; } = null!;

}