namespace PDI.AppServiceDispatcher.Model
{
    using System;
    public interface IDispatcher
    {
        #region Dumpsters
        public string AddDumpster(DumpsterData dumpster);
        public string EditDumpster(DumpsterData dumpster);
        public string DeleteDumpster(string id);
        public DumpsterData[] GetDumpsters();
        #endregion

        #region Measurements
        public string DeleteMeasurement(string id);
        public string DeleteOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetMeasurements();
        public MeasurementData[] GetOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetDumpsterMeasurements(string id);
        #endregion

        #region Vehicles
        public string AddVehicle(VehicleData vehicle);
        public string EditVehicle(VehicleData vehicle);
        public string DeleteVehicle(string id);
        public VehicleData[] GetVehicles();
        #endregion

        #region Routes
        public string StartRoute(RouteData routeData);
        public string FinishRoute(RouteData routeData);
        public string CalculateRoute();
        public string DeleteRoute(RouteData routeData);
        public RouteData[] GetRoutes();
        public RouteData[] GetOldRoutes();
        #endregion





    }
}
