namespace PDI.SimulationModule.Model
{
    public interface ISimulator
    {
        public void RunSimulation();
        public string ChangeSimulationState(SimulationState state);
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters);
        public string AddData(MeasurementData measurement);
    }
}
