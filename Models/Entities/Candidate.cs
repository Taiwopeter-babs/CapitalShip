using Newtonsoft.Json;

namespace CapitalShip.Models;

public class Candidate : BaseEntity
{
    // [JsonProperty(PropertyName = "programmeId")]
    // public int ProgrammeId { get; set; }


    [JsonProperty(PropertyName = "answers")]
    public List<Answer>? Answers { get; set; }
}