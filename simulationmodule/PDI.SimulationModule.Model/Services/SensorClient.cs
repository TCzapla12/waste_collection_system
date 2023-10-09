namespace PDI.SimulationModule.Model
{
    using System.Diagnostics;
    using System;
    using System.Net.Http;

    public class SensorClient: ISensorClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "Sensor/";
        public SensorClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }
        public string AddData(MeasurementData measurement)
        {
            string callUri = String.Format(this.uriPrefix + "AddData");

            string response = this.serviceClient.CallWebService<string, MeasurementData>(HttpMethod.Post, callUri, measurement);

            return response;
        }
        public DumpsterData[] GetDumpsters()
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsters");

            DumpsterData[] response = this.serviceClient.CallWebService<DumpsterData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            string callUri = String.Format(this.uriPrefix + "EmptyMeasurements");

            string response = this.serviceClient.CallWebService<string, EmptyMeasurementsData>(HttpMethod.Put, callUri, emptyMeasurements);

            return response;
        }

    }
}
