using System.Text.Json;

namespace CapitalShip.Exceptions;

public class ErrorDetails
{
    public string? Message { get; set; }
    public int StatusCode { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}