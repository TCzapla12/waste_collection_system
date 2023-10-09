namespace PDI.AppServiceDispatcher.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleState
    {
        enabled,
        disabled,
        working,
        assigned,
    }
}
