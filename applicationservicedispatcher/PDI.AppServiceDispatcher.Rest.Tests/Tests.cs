namespace PDI.AppServiceDispatcher.Rest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Net.Http;
    using System.Text.Json;

    using PDI.AppServiceDispatcher.Model;
    using PDI.AppServiceDispatcher.Logic;

    using PDI.AppServiceDispatcher.Rest.Model;

    public class Tests : ITestsService
    {
        private IDispatcher dispatcher;

        private static readonly HttpClient httpClient = new();


        enum DataService
        {
            dumpsters,
            measurements,
            vehicles,
            routes,
            processing
        }

        public Tests(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public string RunTests(string host, int port, string dataService)
        {
            Debug.Assert(condition: port > 0);

            string uriSuffix = String.Empty;
            HttpMethod method = HttpMethod.Get;

            try
            {
                switch ((DataService)Enum.Parse(typeof(DataService), dataService))
                {
                    case DataService.dumpsters:
                        {
                            uriSuffix = "GetDumpsters";
                            DumpsterData[] dumpsters1 = this.dispatcher.GetDumpsters();
                            DumpsterData[] dumpsters2 = this.GetData<DumpsterData[]>(host, (ushort)port, uriSuffix, method);
                            Debug.Assert(condition: dumpsters1.Length == dumpsters2.Length);
                            break;
                        }
                    case DataService.measurements:
                        {
                            uriSuffix = "GetMeasurements";
                            MeasurementData[] measurements1 = this.dispatcher.GetMeasurements();
                            MeasurementData[] measurements2 = this.GetData<MeasurementData[]>(host, (ushort)port, uriSuffix, method);
                            Debug.Assert(condition: measurements1.Length == measurements2.Length);
                            break;
                        }
                    case DataService.vehicles:
                        {
                            uriSuffix = "GetVehicles";
                            VehicleData[] vehicles1 = this.dispatcher.GetVehicles();
                            VehicleData[] vehicles2 = this.GetData<VehicleData[]>(host, (ushort)port, uriSuffix, method);
                            Debug.Assert(condition: vehicles1.Length == vehicles2.Length);
                            break;
                        }
                    case DataService.routes:
                        {
                            uriSuffix = "GetRoutes";
                            RouteData[] routes1 = this.dispatcher.GetRoutes();
                            RouteData[] routes2 = this.GetData<RouteData[]>(host, (ushort)port, uriSuffix, method);
                            Debug.Assert(condition: routes1.Length == routes2.Length);
                            break;
                        }
                    case DataService.processing:
                        {
                            uriSuffix = "CalculateRoute";
                            method = HttpMethod.Post;
                            string response1 = this.dispatcher.CalculateRoute();
                            string response2 = this.GetData<string>(host, (ushort)port, uriSuffix, method);
                            Debug.Assert(condition: response1 == response2);
                            break;
                        }
                    default:
                        {
                            return "Invalid data service";
                        }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "No errors";
        }

        private R GetData<R>(string webServiceHost, ushort webServicePort, string webSeriveUriSuffix, HttpMethod httpMethod)
        {
            string webServiceUri = String.Format("http://{0}:{1}/Dispatcher/{2}", webServiceHost, webServicePort, webSeriveUriSuffix);

            Task<string> webServiceCall = CallWebService(httpMethod, webServiceUri);

            webServiceCall.Wait();

            string jsonResponseContent = webServiceCall.Result;

            R response = ConvertJson<R>(jsonResponseContent);

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

        public R ConvertJson<R>(string json)
        {
            R data = JsonSerializer.Deserialize<R>(json);

            return data;
        }
    }
}
