namespace PDI.ProcessingServiceRoutes.Model
{
    using System.Diagnostics;
    using System;
    using System.Net.Http;
    using System.Collections.Generic;

    public class DumpstersClient: IDumpstersClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "DumpstersDatabase/";
        public DumpstersClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public string ChangeDumpstersState(List<string> ids, string state)
        {
            ChangeDumpstersStateData data = new ChangeDumpstersStateData() { Ids = ids, State = state };

            string callUri = String.Format(this.uriPrefix + "ChangeDumpstersState");

            string response = this.serviceClient.CallWebService<string, ChangeDumpstersStateData>(HttpMethod.Put, callUri, data);

            return response;
        }
        public DumpsterData[] GetDumpsters()
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsters");

            DumpsterData[] response = this.serviceClient.CallWebService<DumpsterData[]>(HttpMethod.Get, callUri);

            return response;
        }
    }
}
