namespace PDI.AppServiceDispatcher.Model
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
        public static IMeasurementsClient GetMeasurementsClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8081;
            return new MeasurementsClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "dataservice-measurements-api";
            const int servicePort = 80;
            return new MeasurementsClient(serviceHost, servicePort);
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

        public static IProcessingClient GetProcessingClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8085;
            return new ProcessingClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "processservice-routes-api";
            const int servicePort = 80;
            return new ProcessingClient(serviceHost, servicePort);
#endif
        }

        public static ISimulatorClient GetSimulatorClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8087;
            return new SimulatorClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "simulationmodule-sensors-api";
            const int servicePort = 80;
            return new SimulatorClient(serviceHost, servicePort);
#endif
        }

    }
}
