using Newtonsoft.Json;

namespace CapitalShip.Models;

public class Programme : BaseEntity
{
    [JsonProperty(PropertyName = "programTitle")]
    public string? ProgramTitle { get; set; }

    [JsonProperty(PropertyName = "programDescription")]
    public string? ProgramDescription { get; set; }
}