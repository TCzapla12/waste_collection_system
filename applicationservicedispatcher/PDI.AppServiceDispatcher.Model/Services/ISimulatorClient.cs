using System.Collections.Generic;

namespace PDI.AppServiceDispatcher.Model
{
    public interface ISimulatorClient
    {
        public string ChangeSimulationState(string state);
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters);
    }
}
