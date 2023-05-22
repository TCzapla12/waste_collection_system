using System.Diagnostics;
using System;
using System.Net.Http;

namespace PDI.AppServiceDispatcher.Model
{
    public class SimulatorClient : ISimulatorClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "Simulator/";
        public SimulatorClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public string ChangeSimulationState(string state)
        {
            string callUri = String.Format(this.uriPrefix + "ChangeSimulationState/" + state);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Put, callUri);

            return response;
        }

        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            string callUri = String.Format(this.uriPrefix + "EmptyDumpsters");

            string response = this.serviceClient.CallWebService<string, EmptyDumpstersData>(HttpMethod.Put, callUri, emptyDumpsters);

            return response;
        }
    }
}
