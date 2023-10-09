namespace PDI.DataServiceVehicles.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;

    using PDI.DataServiceVehicles.Model;
    using PDI.DataServiceVehicles.Rest.Model;

    public class Tests : ITestsService
    {
        private IVehiclesDatabase vehiclesDatabase;

        private static readonly HttpClient httpClient = new();

        public Tests(IVehiclesDatabase vehiclesDatabase)
        {
            this.vehiclesDatabase = vehiclesDatabase;
        }

        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                Vehicle[] vehicles1 = this.vehiclesDatabase.GetVehicles();

                VehicleData[] vehicles2 = this.GetVehicles(host, (ushort)port);

                Debug.Assert(condition: vehicles1.Length == vehicles2.Length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private VehicleData[] GetVehicles(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("http://{0}:{1}/VehiclesDatabase/GetVehicles", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            VehicleData[] vehicles = ConvertJson(jsonResponseContent);

            return vehicles;
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

        public VehicleData[] ConvertJson(string json)
        {
            VehicleData[] vehicles = JsonSerializer.Deserialize<VehicleData[]>(json);

            return vehicles;
        }
    }
}
