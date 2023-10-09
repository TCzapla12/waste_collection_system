using System;

namespace PDI.ApplicationDispatcher.Model
{
    public interface IOperations
    {        
        #region Dumpsters
        void LoadDumpstersList();
        string AddDumpster(DumpsterData dumpster);
        string EditDumpster(DumpsterData dumpster);
        string DeleteDumpster(string id);
        #endregion

        #region Measurements
        void LoadMeasurementsList();
        void LoadOldMeasurementsList(DateTime dateTime);
        void LoadDumpsterMeasurementsList(string id);
        string DeleteMeasurement(string id);
        string DeleteOldMeasurements(DateTime dateTime);
        #endregion

        #region Vehicles
        void LoadVehiclesList();
        string AddVehicle(VehicleData vehicle);
        string EditVehicle(VehicleData vehicle);
        string DeleteVehicle(string id);
        #endregion

        #region Routes
        void LoadRoutesList();
        void LoadOldRoutesList();
        string DeleteRoute(RouteData routeData);
        string CalculateRoute();
        string StartRoute(RouteData routeData);
        string FinishRoute(RouteData routeData);
        #endregion
    }
}
