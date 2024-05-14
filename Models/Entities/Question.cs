using Newtonsoft.Json;

namespace CapitalShip.Models;


public abstract class BaseQuestion
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    /// <summary>
    /// This property adheres to the QuestionType enum.
    /// The enum is used to validate the DTO with fluent validation
    /// </summary>
    [JsonProperty(PropertyName = "questionType")]
    public string? QuestionType { get; set; }

    [JsonProperty(PropertyName = "questionTitle")]
    public string? QuestionTitle { get; set; }
}


public class Question : BaseQuestion
{
}

/// <summary>
/// Answer model for each question submitted by the candidate
/// </summary>
public class Answer : BaseQuestion
{

    [JsonProperty(PropertyName = "questionAnswer")]
    public string? QuestionAnswer { get; set; }
}