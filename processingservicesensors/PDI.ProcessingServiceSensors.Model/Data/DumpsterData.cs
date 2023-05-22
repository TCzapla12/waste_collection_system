namespace PDI.ProcessingServiceSensors.Model
{
    public class DumpsterData
    {
        public string Id { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public int Usage { get; set; }
        public LocationData Location { get; set; }
    }
}
