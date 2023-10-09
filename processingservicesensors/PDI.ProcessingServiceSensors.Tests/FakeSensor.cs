namespace PDI.ProcessingServiceSensors.Logic
{
    using PDI.ProcessingServiceSensors.Model;

    public class FakeSensor : ISensor
    {
        public FakeSensor()
        {
        }

        private static readonly DumpsterData[] dumpsters = new DumpsterData[]
        {
            new DumpsterData(){Id = "dumpster1", State = DumpsterState.enabled.ToString(),Capacity = 10, Usage = 100, Location = new LocationData(){X = 0, Y = 0}},
            new DumpsterData(){Id = "dumpster2", State = DumpsterState.disabled.ToString(), Capacity = 20, Usage = 0, Location = new LocationData(){ X = 10, Y = 10}}
        };

        public string AddData(MeasurementData measurement)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public DumpsterData[] GetDumpsters()
        {
            return dumpsters;
        }
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            return Message.GetMessage(MessageEnum.success);
        }
    }
}
