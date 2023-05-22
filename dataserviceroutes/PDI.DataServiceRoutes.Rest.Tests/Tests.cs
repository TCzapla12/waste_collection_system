namespace PDI.DataServiceRoutes.Rest.Tests
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Text.Json;

    using PDI.DataServiceRoutes.Model;
    using PDI.DataServiceRoutes.Rest.Model;

    public class Tests : ITestsService
    {
        private IRoutesDatabase routesDatabase;

        private static readonly HttpClient httpClient = new();

        public Tests(IRoutesDatabase routesDatabse)
        {
            this.routesDatabase = routesDatabse;
        }

        public string RunTests(string host, int port)
        {
            Debug.Assert(condition: port > 0);

            try
            {
                Route[] routes1 = this.routesDatabase.GetRoutes();

                RouteData[] routes2 = this.GetRoutes(host, (ushort)port);

                Debug.Assert(condition: routes1.Length == routes2.Length);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private RouteData[] GetRoutes(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("http://{0}:{1}/RoutesDatabase/GetRoutes", webServiceHost, webServicePort);

            Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            RouteData[] routes = ConvertJson(jsonResponseContent);

            return routes;
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

        public RouteData[] ConvertJson(string json)
        {
            RouteData[] routes = JsonSerializer.Deserialize<RouteData[]>(json);

            return routes;
        }
    }
}
