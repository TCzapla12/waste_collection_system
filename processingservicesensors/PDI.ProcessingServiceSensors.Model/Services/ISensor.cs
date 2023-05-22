namespace PDI.ProcessingServiceSensors.Model
{
    public interface ISensor
    {
        public string AddData(MeasurementData measurement);
        public DumpsterData[] GetDumpsters();
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements);
    }
}
