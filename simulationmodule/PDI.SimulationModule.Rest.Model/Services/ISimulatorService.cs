using PDI.SimulationModule.Model;

namespace PDI.SimulationModule.Rest.Model
{
  public interface ISimulatorService
  {
        public string ChangeSimulationState(string state);
        public string EmptyDumpsters(EmptyDumpstersData dumpstersData);
    }
}
