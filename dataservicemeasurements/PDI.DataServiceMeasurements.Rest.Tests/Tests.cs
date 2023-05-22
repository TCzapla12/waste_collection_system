namespace PDI.DataServiceMeasurements.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;

    using PDI.DataServiceMeasurements.Model;
    using PDI.DataServiceMeasurements.Rest.Model;

    public class Tests : ITestsService
    {
        private IMeasurementsDatabase measurementsDatabase;

        private static readonly HttpClient httpClient = new();

        public Tests(IMeasurementsDatabase measurementsDatabase)
        {
            this.measurementsDatabase = measurementsDatabase;
        }
        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                Measurement[] measurements1 = this.measurementsDatabase.GetMeasurements();

                MeasurementData[] measurements2 = this.GetMeasurements(host, (ushort)port);

                Debug.Assert( condition: measurements1.Length == measurements2.Length );
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private MeasurementData[] GetMeasurements(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("http://{0}:{1}/MeasurementsDatabase/GetMeasurements", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            MeasurementData[] measurements = ConvertJson(jsonResponseContent);

            return measurements;
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

        public MeasurementData[] ConvertJson(string json)
        {
            MeasurementData[] measurements = JsonSerializer.Deserialize<MeasurementData[]>(json);

            return measurements;
        }
    }
}
