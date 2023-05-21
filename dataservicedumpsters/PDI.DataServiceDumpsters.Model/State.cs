namespace PDI.DataServiceDumpsters.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum State
    {
        enabled,
        disabled,
        assigned,
        fault,
        faultAssigned
    }
}
