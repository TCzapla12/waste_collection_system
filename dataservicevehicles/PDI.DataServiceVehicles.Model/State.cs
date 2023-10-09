namespace PDI.DataServiceVehicles.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum State
    {
        enabled,
        disabled,
        working,
        assigned,
    }
}
