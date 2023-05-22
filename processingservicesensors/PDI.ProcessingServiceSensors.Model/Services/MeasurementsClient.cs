using System.Diagnostics;
using System;
using System.Net.Http;

namespace PDI.ProcessingServiceSensors.Model
{
    public class MeasurementsClient : IMeasurementsClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "MeasurementsDatabase/";
        public MeasurementsClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }
        public string AddMeasurement(MeasurementData measurement)
        {
            string callUri = String.Format(this.uriPrefix + "AddMeasurement");

            string response = this.serviceClient.CallWebService<string, MeasurementData>(HttpMethod.Post, callUri, measurement);

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
