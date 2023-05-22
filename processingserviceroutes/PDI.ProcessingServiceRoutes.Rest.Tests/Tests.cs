namespace PDI.ProcessingServiceRoutes.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;

    using PDI.ProcessingServiceRoutes.Model;
    using PDI.ProcessingServiceRoutes.Rest.Model;


    public class Tests : ITestsService
    {
        private IRoute route;

        private static readonly HttpClient httpClient = new();

        public Tests(IRoute route)
        {
            this.route = route;
        }

        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                string response1 = this.route.CalculateRoute();

                string response2 = this.CalculateRoute(host, (ushort)port);

                Debug.Assert( condition: response1 == response2 );
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private string CalculateRoute(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("http://{0}:{1}/Route/CalculateRoute", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Post, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            string response = ConvertJson(jsonResponseContent);

            return response;
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

        public string ConvertJson(string json)
        {
            string response = JsonSerializer.Deserialize<string>(json);

            return response;
        }
    }
}
