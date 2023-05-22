namespace PDI.ProcessingServiceSensors.Model
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
        
    }
}
