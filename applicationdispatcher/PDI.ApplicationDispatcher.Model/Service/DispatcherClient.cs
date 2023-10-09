namespace PDI.ApplicationDispatcher.Model
{
    using System;
    using System.Diagnostics;
    using System.Net.Http;

    public class DispatcherClient : IDispatcher
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "Dispatcher/";

        public DispatcherClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        #region Dumpsters
        public DumpsterData[] GetDumpsters()
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsters");

            DumpsterData[] response = this.serviceClient.CallWebService<DumpsterData[]>(HttpMethod.Get, callUri);

            return response;
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
        #endregion

        #region Measurements
        public MeasurementData[] GetMeasurements()
        {
            string callUri = String.Format(uriPrefix + "GetMeasurements");

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("s");

            string callUri = String.Format(uriPrefix + "GetOldMeasurements/" + formattedDateTime);

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            string callUri = String.Format(uriPrefix + "GetDumpsterMeasurements/" + id);

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public string DeleteMeasurement(string id)
        {
            string callUri = String.Format(uriPrefix + "DeleteMeasurement/" + id);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("s");

            string callUri = String.Format(uriPrefix + "DeleteOldMeasurements/" + formattedDateTime);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        #endregion

        #region Vehicles
        public VehicleData[] GetVehicles()
        {
            string callUri = String.Format(this.uriPrefix + "GetVehicles");

            VehicleData[] response = this.serviceClient.CallWebService<VehicleData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public string AddVehicle(VehicleData vehicle)
        {
            string callUri = String.Format(this.uriPrefix + "AddVehicle");

            string response = this.serviceClient.CallWebService<string, VehicleData>(HttpMethod.Post, callUri, vehicle);

            return response;
        }
        public string EditVehicle(VehicleData vehicle)
        {
            string callUri = String.Format(this.uriPrefix + "EditVehicle");

            string response = this.serviceClient.CallWebService<string, VehicleData>(HttpMethod.Put, callUri, vehicle);

            return response;
        }
        public string DeleteVehicle(string id)
        {
            string callUri = String.Format(this.uriPrefix + "DeleteVehicle/" + id);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        #endregion

        #region Routes
        public RouteData[] GetRoutes()
        {
            string callUri = String.Format(this.uriPrefix + "GetRoutes");

            RouteData[] response = this.serviceClient.CallWebService<RouteData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public RouteData[] GetOldRoutes()
        {
            string callUri = String.Format(this.uriPrefix + "GetOldRoutes");

            RouteData[] response = this.serviceClient.CallWebService<RouteData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public string DeleteRoute(RouteData routeData)
        {
            string callUri = String.Format(this.uriPrefix + "DeleteRoute");

            string response = this.serviceClient.CallWebService<string, RouteData>(HttpMethod.Delete, callUri, routeData);

            return response;
        }
        public string CalculateRoute()
        {
            string callUri = String.Format(this.uriPrefix + "CalculateRoute/");

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Post, callUri);

            return response;
        }
        public string FinishRoute(RouteData routeData)
        {
            string callUri = String.Format(this.uriPrefix + "FinishRoute");

            string response = this.serviceClient.CallWebService<string, RouteData>(HttpMethod.Put, callUri, routeData);

            return response;
        }

        public string StartRoute(RouteData routeData)
        {
            string callUri = String.Format(this.uriPrefix + "StartRoute");

            string response = this.serviceClient.CallWebService<string, RouteData>(HttpMethod.Put, callUri, routeData);

            return response;
        }
        #endregion


    }
}
