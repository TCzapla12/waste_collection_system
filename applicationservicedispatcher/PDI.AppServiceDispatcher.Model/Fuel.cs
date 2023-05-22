namespace PDI.AppServiceDispatcher.Model
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Fuel
    {
        ON,
        CNG,
        LPG,
        LNG,
        Pb95,
        Pb98,
        Electric,
        Hybrid,
        E85,
        H2,
    }
}
