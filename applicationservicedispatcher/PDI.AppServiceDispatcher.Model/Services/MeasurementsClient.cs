using System.Diagnostics;
using System;
using System.Net.Http;
using System.Globalization;

namespace PDI.AppServiceDispatcher.Model
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
        public string DeleteMeasurement(string id)
        {
            string callUri = String.Format(this.uriPrefix + "DeleteMeasurement/" + id);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("s");

            string callUri = String.Format(this.uriPrefix + "DeleteOldMeasurements/" + formattedDateTime);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        public MeasurementData[] GetMeasurements()
        {
            string callUri = String.Format(this.uriPrefix + "GetMeasurements");

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            string formattedDateTime = dateTime.ToString("s");

            string callUri = String.Format(this.uriPrefix + "GetOldMeasurements/" + formattedDateTime);

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            string callUri = String.Format(this.uriPrefix + "GetDumpsterMeasurements/" + id);

            MeasurementData[] response = this.serviceClient.CallWebService<MeasurementData[]>(HttpMethod.Get, callUri);

            return response;
        }
    }
}
