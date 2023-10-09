namespace PDI.ProcessingServiceRoutes.Model
{
    public static class ClientFactory
    {
        public static IDumpstersClient GetDumpstersClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8080;
            return new DumpstersClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "dataservice-dumpsters-api";
            const int servicePort = 80;
            return new DumpstersClient(serviceHost, servicePort);
#endif
        }
        public static IVehiclesClient GetVehiclesClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8082;
            return new VehiclesClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "dataservice-vehicles-api";
            const int servicePort = 80;
            return new VehiclesClient(serviceHost, servicePort);
#endif
        }
        public static IRoutesClient GetRoutesClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8083;
            return new RoutesClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "dataservice-routes-api";
            const int servicePort = 80;
            return new RoutesClient(serviceHost, servicePort);
#endif
        }
        public static IBingMapsAPI GetBingMapsAPI()
        {
#if DEBUG
            return new BingMapsAPI();
#else
            //return new FakeClient();
            return new BingMapsAPI();
#endif
        }

    }
}
