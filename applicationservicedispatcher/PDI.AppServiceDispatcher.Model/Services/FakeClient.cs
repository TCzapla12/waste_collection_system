using System;
using System.Collections.Generic;

namespace PDI.AppServiceDispatcher.Model
{
    public class FakeClient : IDumpstersClient, IMeasurementsClient, IRoutesClient, IVehiclesClient
    {
        public string AddDumpster(DumpsterData dumpster)
        {
            throw new System.NotImplementedException();
        }

        public string AddVehicle(VehicleData vehicle)
        {
            throw new System.NotImplementedException();
        }

        public string ChangeRouteState(string id, string state)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteDumpster(string id)
        {
            throw new System.NotImplementedException();
        }

        

        public string DeleteRoute(string id)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteVehicle(VehicleData vehicle)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteVehicle(string id)
        {
            throw new System.NotImplementedException();
        }

        public string EditDumpster(DumpsterData dumpster)
        {
            throw new System.NotImplementedException();
        }

        public string EditVehicle(VehicleData vehicle)
        {
            throw new System.NotImplementedException();
        }
        #region Measurements
        public MeasurementData[] GetMeasurements()
        {
            throw new NotImplementedException();
        }
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            throw new NotImplementedException();
        }
        public string DeleteMeasurement(string id)
        {
            throw new NotImplementedException();
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        #endregion
        public DumpsterData[] GetDumpsters()
        {
            throw new System.NotImplementedException();
        }

        

        public RouteData[] GetRoutes()
        {
            throw new System.NotImplementedException();
        }
        public RouteData[] GetOldRoutes()
        {
            throw new System.NotImplementedException();
        }
        public VehicleData[] GetVehicles()
        {
            throw new System.NotImplementedException();
        }

        public string ChangeDumpstersState(List<string> ids, string state)
        {
            throw new NotImplementedException();
        }

        public string ChangeVehicleState(string id, string state)
        {
            throw new NotImplementedException();
        }

        
    }
}
