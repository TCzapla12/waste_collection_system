namespace PDI.ApplicationDispatcher.Model
{
    using System;
    using System.Linq;

    public class FakeDispatcherClient : IDispatcher
    {

        private static readonly RouteData[] nodes = new RouteData[] 
        { 
            new RouteData() { Id = "node1"}, 
            new RouteData() { Id = "node2"} 
        };

        #region Dumpsters
        private static readonly DumpsterData[] dumpsters = new DumpsterData[]
        {
            new DumpsterData() {
                Id = "dumpster1",
                State = DumpsterState.enabled,
                Capacity = 10,
                Usage = 100,
                Location = new LocationData { X = 0, Y = 0 }
            },
            new DumpsterData() {
                Id = "dumpster2",
                State = DumpsterState.disabled,
                Capacity = 20,
                Usage = 0,
                Location = new LocationData { X = 10, Y = 10 }
            }
        };
        public DumpsterData[] GetDumpsters()
        {
            return FakeDispatcherClient.dumpsters;
        }
        public string AddDumpster(DumpsterData dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string EditDumpster(DumpsterData dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteDumpster(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        #endregion

        #region Measurements
        private static readonly MeasurementData[] measurements = new MeasurementData[]
        {
            new MeasurementData() { Id = "measurement1", DumpsterId = "dumpster1", DateTime = DateTime.MinValue.ToString(), Usage = 30},
            new MeasurementData() { Id = "measurement2", DumpsterId = "dumpster1", DateTime = DateTime.Now.ToString(), Usage = 40}
        };
        public MeasurementData[] GetMeasurements()
        {
            return FakeDispatcherClient.measurements;
        }

        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Vehicles
        #endregion

        #region Routes
        #endregion

        public string AddVehicle(VehicleData vehicle)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string ChangeRouteState(string id, string state)
        {
            return Message.GetMessage(MessageEnum.success);
        }



        public void DeleteRoute(string id)
        {
            throw new NotImplementedException();
        }


        public string DeleteVehicle(string id)
        {
            throw new NotImplementedException();
        }


        public string EditVehicle(VehicleData vehicle)
        {
            throw new NotImplementedException();
        }

        public void FinishRoute(string id)
        {
            throw new NotImplementedException();
        }



        

        public RouteData[] GetRoutes(string searchText)
        {
            return FakeDispatcherClient.nodes.Where(node => node.Id.IndexOf(searchText) >= 0).ToArray();
        }

        public RouteData[] GetRoutes()
        {
            throw new NotImplementedException();
        }
        public RouteData[] GetOldRoutes()
        {
            throw new NotImplementedException();
        }

        public VehicleData[] GetVehicles()
        {
            throw new NotImplementedException();
        }

        public void StartRoute(string id)
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

        string IDispatcher.DeleteRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }

        public string CalculateRoute()
        {
            throw new NotImplementedException();
        }

        string IDispatcher.StartRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }

        string IDispatcher.FinishRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }
    }
}
