namespace PDI.SimulationModule.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;
    using System.Net.Http.Json;

    using PDI.SimulationModule.Model;
    using PDI.SimulationModule.Rest.Model;
    

    public class Tests : ITestsService
    {
        private ISimulator simulator;

        private static readonly HttpClient httpClient = new();

        public Tests(ISimulator simulator)
        {
            this.simulator = simulator;
        }

        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                MeasurementData measurement = new MeasurementData()
                { Id = "measurement1", DateTime = "2022-10-04T16:42:01.8997816+02:00",
                Usage = 10, DumpsterId = "dumpster1"};

                string response1 = this.simulator.AddData(measurement);

                Console.WriteLine(response1);

                string response2 = this.AddData(host, (ushort)port, measurement);

                Console.WriteLine(response2);

                Debug.Assert( condition: response1 == response2 );
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private string AddData(string webServiceHost, ushort webServicePort, MeasurementData measurement)
        {
            string webServiceUri = String.Format("http://{0}:{1}/Sensor/AddData", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, webServiceUri, measurement);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            string response = ConvertJson(jsonResponseContent);

            return response;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri, MeasurementData content)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            httpRequestMessage.Content = JsonContent.Create(content);

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public string ConvertJson(string json)
        {
            string response = JsonSerializer.Deserialize<string>(json);

            return response;
        }
    }
}
