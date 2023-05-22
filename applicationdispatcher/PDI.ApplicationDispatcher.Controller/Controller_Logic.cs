namespace PDI.ApplicationDispatcher.Controller
{
    using PDI.ApplicationDispatcher.Model;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Windows.Input;

    public partial class Controller : IController
    {
        public ApplicationState CurrentState
        {
            get { return this.currentState; }
            set
            {
                this.currentState = value;

                this.RaisePropertyChanged("CurrentState");
            }
        }
        private ApplicationState currentState = ApplicationState.List;

        public ICommand SearchNodesCommand { get; private set; }

        public ICommand ShowListCommand { get; private set; }

        public ICommand ShowMapCommand { get; private set; }
        
        public async Task ShowListAsync()
        {
            await Task.Run(() => this.ShowList());
        }

        public async Task ShowMapAsync()
        {
            await Task.Run(() => this.ShowMap());
        }

        private void ShowList()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.List:
                    break;

                default:
                    this.CurrentState = ApplicationState.List;
                    break;
            }
        }

        private void ShowMap()
        {
            switch (this.CurrentState)
            {
                case ApplicationState.Map:
                    break;

                default:
                    this.CurrentState = ApplicationState.Map;
                    break;
            }
        }

        #region Dumpsters
        public async Task SearchDumpstersAsync()
        {
            await Task.Run(() => this.SearchDumpsters());
        }
        public async Task<string> AddDumpsterAsync(DumpsterData dumpster)
        {
            return await Task.Run(() => this.AddDumpster(dumpster));
        }
        public async Task<string> EditDumpsterAsync(DumpsterData dumpster)
        {
            return await Task.Run(() => this.EditDumpster(dumpster));
        }
        public async Task<string> DeleteDumpsterAsync(string id)
        {
            return await Task.Run(() => this.DeleteDumpster(id));
        }
        private void SearchDumpsters()
        {
            this.Model.LoadDumpstersList();
        }
        private string AddDumpster(DumpsterData dumpster)
        {
            return this.Model.AddDumpster(dumpster);
        }
        private string EditDumpster(DumpsterData dumpster)
        {
            return this.Model.EditDumpster(dumpster);
        }
        private string DeleteDumpster(string id)
        {
            return this.Model.DeleteDumpster(id);
        }
        #endregion

        #region Measurements
        public async Task SearchMeasurementsAsync()
        {
            await Task.Run(() => this.SearchMeasurements());
        }
        public async Task SearchOldMeasurementsAsync(DateTime dateTime)
        {
            await Task.Run(() => this.SearchOldMeasurements(dateTime));
        }
        public async Task SearchDumpsterMeasurementsAsync(string id)
        {
            await Task.Run(() => this.SearchDumpsterMeasurements(id));
        }
        public async Task<string> DeleteMeasurementAsync(string id)
        {
            return await Task.Run(() => this.DeleteMeasurement(id));
        }
        public async Task<string> DeleteOldMeasurementsAsync(DateTime dateTime)
        {
            return await Task.Run(() => this.DeleteOldMeasurements(dateTime));
        }
        private void SearchMeasurements()
        {
            this.Model.LoadMeasurementsList();
        }
        private void SearchOldMeasurements(DateTime dateTime)
        {
            this.Model.LoadOldMeasurementsList(dateTime);
        }
        private void SearchDumpsterMeasurements(string id)
        {
            this.Model.LoadDumpsterMeasurementsList(id);
        }
        private string DeleteMeasurement(string id)
        {
            return this.Model.DeleteMeasurement(id);
        }
        private string DeleteOldMeasurements(DateTime dateTime)
        {
            return this.Model.DeleteOldMeasurements(dateTime);
        }
        #endregion

        #region Vehicles
        public async Task SearchVehiclesAsync()
        {
            await Task.Run(() => this.SearchVehicles());
        }
        public async Task<string> AddVehicleAsync(VehicleData vehicle)
        {
            return await Task.Run(() => this.AddVehicle(vehicle));
        }
        public async Task<string> EditVehicleAsync(VehicleData vehicle)
        {
            return await Task.Run(() => this.EditVehicle(vehicle));
        }
        public async Task<string> DeleteVehicleAsync(string id)
        {
            return await Task.Run(() => this.DeleteVehicle(id));
        }
        private void SearchVehicles()
        {
            this.Model.LoadVehiclesList();
        }
        private string AddVehicle(VehicleData vehicle)
        {
            return this.Model.AddVehicle(vehicle);
        }
        private string EditVehicle(VehicleData vehicle)
        {
            return this.Model.EditVehicle(vehicle);
        }
        private string DeleteVehicle(string id)
        {
            return this.Model.DeleteVehicle(id);
        }
        #endregion

        #region Routes
        public async Task SearchRoutesAsync()
        {
            await Task.Run(() => this.SearchRoutes());
        }
        public async Task SearchOldRoutesAsync()
        {
            await Task.Run(() => this.SearchOldRoutes());
        }
        public async Task<string> DeleteRouteAsync(RouteData routeData)
        {
            return await Task.Run(() => this.DeleteRoute(routeData));
        }
        public async Task<string> CalculateRouteAsync()
        {
            return await Task.Run(() => this.CalculateRoute());
        }
        public async Task<string> StartRouteAsync(RouteData routeData)
        {
            return await Task.Run(() => this.StartRoute(routeData));
        }
        public async Task<string> FinishRouteAsync(RouteData routeData)
        {
            return await Task.Run(() => this.FinishRoute(routeData));
        }
        private void SearchRoutes()
        {
            this.Model.LoadRoutesList();
        }
        private void SearchOldRoutes()
        {
            this.Model.LoadOldRoutesList();
        }
        private string DeleteRoute(RouteData routeData)
        {
            return this.Model.DeleteRoute(routeData);
        }
        private string CalculateRoute()
        {
            return this.Model.CalculateRoute();
        }
        private string StartRoute(RouteData routeData)
        {
            return this.Model.StartRoute(routeData);
        }
        private string FinishRoute(RouteData routeData)
        {
            return this.Model.FinishRoute(routeData);
        }
        #endregion
    }
}
