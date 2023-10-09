namespace PDI.SimulationModule.Model
{
    public interface ISensorClient
    {
        public string AddData(MeasurementData measurement);
        public DumpsterData[] GetDumpsters();
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements);
    }
}
