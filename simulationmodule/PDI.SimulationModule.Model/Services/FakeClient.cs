namespace PDI.SimulationModule.Model
{
    public class FakeClient : ISensorClient
    {
        public string AddData(MeasurementData measurement)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            throw new System.NotImplementedException();
        }

        public DumpsterData[] GetDumpsters()
        {
            throw new System.NotImplementedException();
        }
    }
}
