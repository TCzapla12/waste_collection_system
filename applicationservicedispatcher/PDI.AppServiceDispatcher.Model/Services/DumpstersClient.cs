namespace PDI.AppServiceDispatcher.Model
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
        public string AddDumpster(DumpsterData dumpster)
        {
            string callUri = String.Format(this.uriPrefix + "AddDumpster");

            string response = this.serviceClient.CallWebService<string, DumpsterData>(HttpMethod.Post, callUri, dumpster);

            return response;
        }
        public string EditDumpster(DumpsterData dumpster)
        {
            string callUri = String.Format(this.uriPrefix + "EditDumpster");

            string response = this.serviceClient.CallWebService<string, DumpsterData>(HttpMethod.Put, callUri, dumpster);

            return response;
        }
        public string DeleteDumpster(string id)
        {
            string callUri = String.Format(this.uriPrefix + "DeleteDumpster/" + id);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        public DumpsterData[] GetDumpsters()
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsters");

            DumpsterData[] response = this.serviceClient.CallWebService<DumpsterData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public string ChangeDumpstersState(List<string> ids, string state)
        {
            ChangeDumpstersStateData data = new ChangeDumpstersStateData() { Ids = ids, State = state };

            string callUri = String.Format(this.uriPrefix + "ChangeDumpstersState");

            string response = this.serviceClient.CallWebService<string, ChangeDumpstersStateData>(HttpMethod.Put, callUri, data);

            return response;
        }
    }
}
