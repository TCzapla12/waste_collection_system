namespace PDI.ProcessingServiceSensors.Model
{
    public interface IMeasurementsClient
    {
        public string AddMeasurement(MeasurementData measurement);
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements);
    }
}
