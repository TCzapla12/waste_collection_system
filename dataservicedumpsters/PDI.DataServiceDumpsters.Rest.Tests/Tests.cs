namespace PDI.DataServiceDumpsters.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;

    using PDI.DataServiceDumpsters.Model;
    using PDI.DataServiceDumpsters.Rest.Model;

    public class Tests : ITestsService
    {
        private IDumpstersDatabase dumpstersDatabase;

        private static readonly HttpClient httpClient = new();

        public Tests(IDumpstersDatabase dumpstersDatabase)
        {
            this.dumpstersDatabase = dumpstersDatabase;
        }

        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                Dumpster[] dumpsters1 = this.dumpstersDatabase.GetDumpsters();

                DumpsterData[] dumpsters2 = this.GetDumpsters(host, (ushort)port);

                Debug.Assert(condition: dumpsters1.Length == dumpsters2.Length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private DumpsterData[] GetDumpsters(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("http://{0}:{1}/DumpstersDatabase/GetDumpsters", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            DumpsterData[] dumpsters = ConvertJson(jsonResponseContent);

            return dumpsters;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public DumpsterData[] ConvertJson(string json)
        {
            DumpsterData[] dumpsters = JsonSerializer.Deserialize<DumpsterData[]>(json);

            return dumpsters;
        }
    }
}
