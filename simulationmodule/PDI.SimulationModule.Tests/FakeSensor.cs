namespace PDI.SimulationModule.Logic
{
    using PDI.SimulationModule.Model;

    public class FakeSensor : ISimulator
    {
        public FakeSensor()
        {
        }

        public string AddData(MeasurementData measurement)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string ChangeSimulationState(SimulationState state)
        {
            throw new System.NotImplementedException();
        }

        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            throw new System.NotImplementedException();
        }

        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public DumpsterData[] GetDumpsters()
        {
            throw new System.NotImplementedException();
        }

        public void RunSimulation()
        {
            throw new System.NotImplementedException();
        }
    }
}
