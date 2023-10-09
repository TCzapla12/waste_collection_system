using System.Diagnostics;
using System;
using System.Net.Http;

namespace PDI.AppServiceDispatcher.Model
{
    public class ProcessingClient: IProcessingClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "Route/";
        public ProcessingClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }
        public string CalculateRoute()
        {
            string callUri = String.Format(this.uriPrefix + "CalculateRoute");

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Post,callUri);

            return response;
        }
    }
}
