namespace PDI.ApplicationDispatcher.Controller
{
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Windows.Input;

    using PDI.ApplicationDispatcher.Model;
    using System;

    public interface IController : INotifyPropertyChanged
    {
        IModel Model { get; }

        ApplicationState CurrentState { get; }

        ICommand SearchNodesCommand { get; }

        ICommand ShowListCommand { get; }

        ICommand ShowMapCommand { get; }

        

        Task ShowListAsync();

        Task ShowMapAsync();

        #region Dumpsters
        Task<string> AddDumpsterAsync(DumpsterData dumpster);
        Task<string> EditDumpsterAsync(DumpsterData dumpster);
        Task<string> DeleteDumpsterAsync(string id);
        Task SearchDumpstersAsync();
        #endregion

        #region Measurements
        Task SearchMeasurementsAsync();
        Task SearchOldMeasurementsAsync(DateTime dateTime);
        Task SearchDumpsterMeasurementsAsync(string id);
        Task<string> DeleteMeasurementAsync(string id);
        Task<string> DeleteOldMeasurementsAsync(DateTime dateTime);
        #endregion

        #region Vehicles
        Task SearchVehiclesAsync();
        Task<string> AddVehicleAsync(VehicleData vehicle);
        Task<string> EditVehicleAsync(VehicleData vehicle);
        Task<string> DeleteVehicleAsync(string id);
        #endregion

        #region Routes
        Task SearchRoutesAsync();
        Task SearchOldRoutesAsync();
        Task<string> CalculateRouteAsync();
        Task<string> StartRouteAsync(RouteData route);
        Task<string> FinishRouteAsync(RouteData route);
        Task<string> DeleteRouteAsync(RouteData route);
        #endregion



    }
}
