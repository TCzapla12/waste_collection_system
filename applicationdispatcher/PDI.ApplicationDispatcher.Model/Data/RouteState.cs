namespace PDI.ApplicationDispatcher.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RouteState
    {
        [Display(Description = "Zbieranie")]
        started,
        [Display(Description = "Oczekiwanie")]
        notStarted,
        [Display(Description = "Zakończono")]
        finished
    }
}
