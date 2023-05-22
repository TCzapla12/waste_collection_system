namespace PDI.ProcessingServiceSensors.Model
{
    public class FakeClient : IDumpstersClient, IMeasurementsClient
    {
        private static readonly DumpsterData[] dumpsters = new DumpsterData[]
        {
            new DumpsterData(){Id = "dumpster1", State = DumpsterState.enabled.ToString(),Capacity = 10, Usage = 100, Location = new LocationData(){X = 0, Y = 0}},
            new DumpsterData(){Id = "dumpster2", State = DumpsterState.disabled.ToString(), Capacity = 20, Usage = 0, Location = new LocationData(){ X = 10, Y = 10}}
        };
        public string ChangeDumpsterUsage(string id, int usage)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public DumpsterData[] GetDumpsters()
        {
            return dumpsters;
        }

        public string AddMeasurement(MeasurementData measurement)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            return Message.GetMessage(MessageEnum.success);
        }
    }
}
