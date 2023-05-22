namespace PDI.ApplicationDispatcher.Model
{
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Linq;

    public partial class Model : IOperations
    {
        IDispatcher dispatcherClient = DispatcherClientFactory.GetDispatcherClient();
        public void LoadNodeList()
        {
            //this.LoadNodesTask();
        }

        #region Dumpsters
        public void LoadDumpstersList()
        {
            this.LoadDumpstersTask();
        }
        public string AddDumpster(DumpsterData dumpster)
        {
            return this.AddDumpsterTask(dumpster);
        }
        public string EditDumpster(DumpsterData dumpster)
        {
            return this.EditDumpsterTask(dumpster);
        }
        public string DeleteDumpster(string id)
        {
            return this.DeleteDumpsterTask(id);
        }
        private void LoadDumpstersTask()
        {
            try
            {
                DumpsterData[] dumpsters = this.dispatcherClient.GetDumpsters();

                this.DumpstersList = dumpsters.ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string AddDumpsterTask(DumpsterData dumpster)
        {
            try
            {
                return this.dispatcherClient.AddDumpster(dumpster);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string EditDumpsterTask(DumpsterData dumpster)
        {
            try
            {
                return this.dispatcherClient.EditDumpster(dumpster);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string DeleteDumpsterTask(string id)
        {
            try
            {
                return this.dispatcherClient.DeleteDumpster(id);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        #endregion

        #region Measurements
        public void LoadMeasurementsList()
        {
            this.LoadMeasurementsTask();
        }
        public void LoadOldMeasurementsList(DateTime dateTime)
        {
            this.LoadOldMeasurementsTask(dateTime);
        }
        public void LoadDumpsterMeasurementsList(string id)
        {
            this.LoadDumpsterMeasurementsTask(id);
        }
        public string DeleteMeasurement(string id)
        {
            return this.DeleteMeasurementTask(id);
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            return this.DeleteOldMeasurementsTask(dateTime);
        }
        private void LoadMeasurementsTask()
        {
            try
            {
                MeasurementData[] measurements = this.dispatcherClient.GetMeasurements();

                this.MeasurementsList = measurements.ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void LoadOldMeasurementsTask(DateTime dateTime)
        {
            try
            {
                MeasurementData[] measurements = this.dispatcherClient.GetOldMeasurements(dateTime);

                this.OldMeasurementsList = measurements.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void LoadDumpsterMeasurementsTask(string id)
        {
            try
            {
                MeasurementData[] measurements = this.dispatcherClient.GetDumpsterMeasurements(id);

                this.DumpsterMeasurementsList = measurements.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string DeleteMeasurementTask(string id)
        {
            try
            {
                return this.dispatcherClient.DeleteMeasurement(id);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string DeleteOldMeasurementsTask(DateTime dateTime)
        {
            try
            {
                return this.dispatcherClient.DeleteOldMeasurements(dateTime);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        #endregion

        #region Vehicles
        public void LoadVehiclesList()
        {
            this.LoadVehiclesTask();
        }
        public string AddVehicle(VehicleData vehicle)
        {
            return this.AddVehicleTask(vehicle);
        }
        public string EditVehicle(VehicleData vehicle)
        {
            return this.EditVehicleTask(vehicle);
        }
        public string DeleteVehicle(string id)
        {
            return this.DeleteVehicleTask(id);
        }
        private void LoadVehiclesTask()
        {
            try
            {
                VehicleData[] vehicles = this.dispatcherClient.GetVehicles();

                this.VehiclesList = vehicles.ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string AddVehicleTask(VehicleData vehicle)
        {
            try
            {
                return this.dispatcherClient.AddVehicle(vehicle);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string EditVehicleTask(VehicleData vehicle)
        {
            try
            {
                return this.dispatcherClient.EditVehicle(vehicle);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string DeleteVehicleTask(string id)
        {
            try
            {
                return this.dispatcherClient.DeleteVehicle(id);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        #endregion

        #region Routes
        public void LoadRoutesList()
        {
            this.LoadRoutesTask();
        }
        public void LoadOldRoutesList()
        {
            this.LoadOldRoutesTask();
        }
        public string DeleteRoute(RouteData routeData)
        {
            return this.DeleteRouteTask(routeData);
        }
        public string CalculateRoute()
        {
            return this.CalculateRouteTask();
        }
        public string StartRoute(RouteData routeData)
        {
            return this.StartRouteTask(routeData);
        }
        public string FinishRoute(RouteData routeData)
        {
            return this.FinishRouteTask(routeData);
        }
        private void LoadRoutesTask()
        {
            try
            {
                RouteData[] routes = this.dispatcherClient.GetRoutes();

                this.RoutesList = routes.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void LoadOldRoutesTask()
        {
            try
            {
                RouteData[] routes = this.dispatcherClient.GetOldRoutes();
                this.OldRoutesList = routes.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string DeleteRouteTask(RouteData routeData)
        {
            try
            {
                return this.dispatcherClient.DeleteRoute(routeData);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string CalculateRouteTask()
        {
            try
            {
                return this.dispatcherClient.CalculateRoute();
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string StartRouteTask(RouteData routeData)
        {
            try
            {
                return this.dispatcherClient.StartRoute(routeData);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        private string FinishRouteTask(RouteData routeData)
        {
            try
            {
                return this.dispatcherClient.FinishRoute(routeData);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error);
            }
        }
        #endregion

    }
}
