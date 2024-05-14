using Newtonsoft.Json;

namespace CapitalShip.Models;

public abstract class BaseEntity
{
    [JsonProperty(PropertyName = "id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();


    [JsonProperty(PropertyName = "firstName")]
    public string? FirstName { get; set; }

    [JsonProperty(PropertyName = "lastName")]
    public string? LastName { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string? Email { get; set; }

    [JsonProperty(PropertyName = "phone")]
    public string? Phone { get; set; }

    [JsonProperty(PropertyName = "nationality")]
    public string? Nationality { get; set; }

    [JsonProperty(PropertyName = "currentResidence")]
    public string? CurrentResidence { get; set; }

    [JsonProperty(PropertyName = "idNumber")]
    public int IdNumber { get; set; }

    [JsonProperty(PropertyName = "birthday")]
    public DateTime Birthday { get; set; }

    [JsonProperty(PropertyName = "gender")]
    public string? Gender { get; set; }
}