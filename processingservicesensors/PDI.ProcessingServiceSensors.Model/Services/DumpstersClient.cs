namespace PDI.ProcessingServiceSensors.Model
{
    using System.Diagnostics;
    using System;
    using System.Net.Http;

    public class DumpstersClient: IDumpstersClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "DumpstersDatabase/";
        public DumpstersClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }
        public string ChangeDumpsterUsage(string id, int usage)
        {
            string callUri = String.Format(this.uriPrefix + "ChangeDumpsterUsage/" + id + "?usage=" + usage);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Put, callUri);

            return response;
        }
        public DumpsterData[] GetDumpsters()
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsters");

            DumpsterData[] response = this.serviceClient.CallWebService<DumpsterData[]>(HttpMethod.Get, callUri);

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
