namespace PDI.ApplicationDispatcher.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;

    public interface IData : INotifyPropertyChanged
    {
        string SearchText { get; set; }

        List<RouteData> RoutesList { get; }
        List<RouteData> OldRoutesList { get; }
        List<VehicleData> VehiclesList { get; }
        List<DumpsterData> DumpstersList { get; }
        List<MeasurementData> MeasurementsList { get; }
        List<MeasurementData> OldMeasurementsList { get; }
        List<MeasurementData> DumpsterMeasurementsList { get; }
    }
}
