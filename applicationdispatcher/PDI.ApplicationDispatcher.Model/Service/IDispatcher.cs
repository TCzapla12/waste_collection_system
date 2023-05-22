using System;

namespace PDI.ApplicationDispatcher.Model
{
    public interface IDispatcher
    {
        #region Dumpsters
        public DumpsterData[] GetDumpsters();
        public string AddDumpster(DumpsterData dumpster);
        public string EditDumpster(DumpsterData dumpster);
        public string DeleteDumpster(string id);
        #endregion

        #region Measurements
        public MeasurementData[] GetMeasurements();
        public MeasurementData[] GetOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetDumpsterMeasurements(string id);
        public string DeleteMeasurement(string id);
        public string DeleteOldMeasurements(DateTime dateTime);
        #endregion

        #region Vehicles
        public VehicleData[] GetVehicles();
        public string AddVehicle(VehicleData vehicle);
        public string EditVehicle(VehicleData vehicle);
        public string DeleteVehicle(string id);

        #endregion

        #region Routes
        public RouteData[] GetRoutes();
        public RouteData[] GetOldRoutes();
        public string DeleteRoute(RouteData routeData);
        public string CalculateRoute();
        public string StartRoute(RouteData routeData);
        public string FinishRoute(RouteData routeData);
        #endregion







    }
}
