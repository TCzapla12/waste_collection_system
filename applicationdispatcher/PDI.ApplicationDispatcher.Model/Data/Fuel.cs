namespace PDI.ApplicationDispatcher.Model
{
    using System.ComponentModel.DataAnnotations;
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
        [Display(Description = "Elektryczny")]
        Electric,
        [Display(Description = "Hybrydowy")]
        Hybrid,
        E85,
        H2,
    }
}
