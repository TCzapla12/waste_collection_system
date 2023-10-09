using System;
using System.Collections.Generic;

namespace PDI.ProcessingServiceRoutes.Model
{
    public class FakeClient : IDumpstersClient, IVehiclesClient, IRoutesClient
    {
        public string AddRoute(RouteData route)
        {
            throw new NotImplementedException();
        }

        public string ChangeDumpstersState(List<string> ids, string state)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string ChangeRouteState(string id, string state)
        {
            throw new NotImplementedException();
        }

        public string ChangeVehicleState(string id, string state)
        {
            throw new NotImplementedException();
        }

        public string DeleteRoute(string id)
        {
            throw new NotImplementedException();
        }

        public string EditRoute(RouteData route)
        {
            throw new NotImplementedException();
        }

        public DumpsterData[] GetDumpsters()
        {
            throw new NotImplementedException();
        }

        public RouteData[] GetRoutes()
        {
            throw new NotImplementedException();
        }

        public VehicleData[] GetVehicles()
        {
            throw new NotImplementedException();
        }
    }
}
