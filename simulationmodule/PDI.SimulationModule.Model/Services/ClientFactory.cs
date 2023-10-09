namespace PDI.SimulationModule.Model
{
    public static class ClientFactory
    {
        public static ISensorClient GetSensorClient()
        {
#if DEBUG
            const string serviceHost = "localhost";
            const int servicePort = 8088;
            return new SensorClient(serviceHost, servicePort);
#else
            //return new FakeClient();
            const string serviceHost = "processservice-sensors-api";
            const int servicePort = 80;
            return new SensorClient(serviceHost, servicePort);
#endif
        }
    }
}
