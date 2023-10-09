namespace PDI.AppServiceDispatcher.Model
{
    using System.Diagnostics;
    using System;
    using System.Net.Http;

    public class VehiclesClient: IVehiclesClient

    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "VehiclesDatabase/";
        public VehiclesClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
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
        public VehicleData[] GetVehicles()
        {
            string callUri = String.Format(this.uriPrefix + "GetVehicles");

            VehicleData[] response = this.serviceClient.CallWebService<VehicleData[]>(HttpMethod.Get, callUri);

            return response;
        }

        public string ChangeVehicleState(string id, string state)
        {
            string callUri = String.Format(this.uriPrefix + "ChangeVehicleState/" + id + "?state=" + state);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Put, callUri);

            return response;
        }
    }
}
