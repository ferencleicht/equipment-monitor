using System.Text.Json.Serialization;
using Api.Domain;

namespace Api.Messages;

public class EquipmentStateChanged
{
    [JsonPropertyName("equipment")]
    public string EquipmentId { get; init; }
    
    [JsonPropertyName("state")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public State State { get; init; }
}
