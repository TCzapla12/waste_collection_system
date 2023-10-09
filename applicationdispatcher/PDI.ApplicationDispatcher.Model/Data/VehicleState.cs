namespace PDI.ApplicationDispatcher.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VehicleState
    {
        [Display(Description = "Dostępna")]
        enabled,
        [Display(Description = "Niedostępna")]
        disabled,
        [Display(Description = "Zbieranie")]
        working,
        [Display(Description = "Oczekiwanie")]
        assigned,
        
    }
}
