namespace PDI.ApplicationDispatcher.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class Model : IData
    {
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;

                this.RaisePropertyChanged("SearchText");
            }
        }
        private string searchText;

        public List<RouteData> RoutesList
        {
            get { return this.routesList; }
            private set
            {
                this.routesList = value;

                this.RaisePropertyChanged("RoutesList");
            }
        }
        private List<RouteData> routesList = new List<RouteData>();
        
        public List<RouteData> OldRoutesList
        {
            get { return this.oldRoutesList; }
            private set
            {
                this.oldRoutesList = value;
                this.RaisePropertyChanged("OldRoutesList");
            }
        }
        private List<RouteData> oldRoutesList = new List<RouteData>();

        public List<VehicleData> VehiclesList
        {
            get { return this.vehiclesList; }
            private set
            {
                this.vehiclesList = value;

                this.RaisePropertyChanged("VehiclesList");
            }
        }
        private List<VehicleData> vehiclesList = new List<VehicleData>();

        public List<DumpsterData> DumpstersList
        {
            get { return this.dumpstersList; }
            private set
            {
                this.dumpstersList = value;

                this.RaisePropertyChanged("DumpstersList");
            }
        }
        private List<DumpsterData> dumpstersList = new List<DumpsterData>();

        public List<MeasurementData> MeasurementsList
        {
            get { return this.measurementsList; }
            private set
            {
                this.measurementsList = value;

                this.RaisePropertyChanged("MeasurementsList");
            }
        }
        private List<MeasurementData> measurementsList = new List<MeasurementData>();

        public List<MeasurementData> OldMeasurementsList
        {
            get { return this.oldMeasurementsList; }
            private set
            {
                this.oldMeasurementsList = value;

                this.RaisePropertyChanged("OldMeasurementsList");
            }
        }
        private List<MeasurementData> oldMeasurementsList = new List<MeasurementData>();

        public List<MeasurementData> DumpsterMeasurementsList
        {
            get { return this.dumpsterMeasurementsList; }
            private set
            {
                this.dumpsterMeasurementsList = value;

                this.RaisePropertyChanged("DumpsterMeasurementsList");
            }
        }
        private List<MeasurementData> dumpsterMeasurementsList = new List<MeasurementData>();
    }
}
