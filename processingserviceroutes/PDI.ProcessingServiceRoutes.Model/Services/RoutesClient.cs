using System.Diagnostics;
using System;
using System.Net.Http;

namespace PDI.ProcessingServiceRoutes.Model
{
    public class RoutesClient : IRoutesClient
    {
        private readonly ServiceClient serviceClient;
        private readonly string uriPrefix = "RoutesDatabase/";
        public RoutesClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }
        public string ChangeRouteState(string id, string state)
        {
            string callUri = String.Format(this.uriPrefix + "ChangeRouteState/" + id + "?state=" + state);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Put, callUri);

            return response;
        }
        public string AddRoute(RouteData route)
        {
            string callUri = String.Format(this.uriPrefix + "AddRoute");

            string response = this.serviceClient.CallWebService<string, RouteData>(HttpMethod.Post, callUri, route);

            return response;
        }
        public string EditRoute(RouteData route)
        {
            string callUri = String.Format(this.uriPrefix + "EditRoute");

            string response = this.serviceClient.CallWebService<string, RouteData>(HttpMethod.Put, callUri, route);

            return response;
        }
        public string DeleteRoute(string id)
        {
            string callUri = String.Format(this.uriPrefix + "DeleteRoute/" + id);

            string response = this.serviceClient.CallWebService<string>(HttpMethod.Delete, callUri);

            return response;
        }
        public RouteData[] GetRoutes()
        {
            string callUri = String.Format(this.uriPrefix + "GetRoutes");

            RouteData[] response = this.serviceClient.CallWebService<RouteData[]>(HttpMethod.Get, callUri);

            return response;
        }
    }
}