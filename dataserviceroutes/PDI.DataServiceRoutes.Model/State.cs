namespace PDI.DataServiceRoutes.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum State
    {
        started,
        notStarted,
        finished
    }
}
