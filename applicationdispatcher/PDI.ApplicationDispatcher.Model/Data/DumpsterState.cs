namespace PDI.ApplicationDispatcher.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DumpsterState
    {
        [Display(Description = "Aktywny")]
        enabled,
        [Display(Description = "Nieaktywny")]
        disabled,
        [Display(Description = "Przypisany")]
        assigned,
        [Display(Description = "Awaria (aktywny)")]
        fault,
        [Display(Description = "Awaria (przypisany)")]
        faultAssigned
    }

}
