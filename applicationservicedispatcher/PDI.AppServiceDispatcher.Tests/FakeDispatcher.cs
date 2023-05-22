namespace PDI.AppServiceDispatcher.Logic
{
    using System;
    using System.Linq;
    using PDI.AppServiceDispatcher.Model;

    public class FakeDispatcher : IDispatcher
    {
        public FakeDispatcher()
        {
        }

        #region Dumpsters
        private static readonly DumpsterData[] dumpsters = new DumpsterData[]
        {
             new DumpsterData() {
                Id = "dumpster1",
                State = DumpsterState.enabled.ToString(),
                Capacity = 10,
                Usage = 100,
                Location = new LocationData { X = 0, Y = 0 }
             },
             new DumpsterData() {
                Id = "dumpster2",
                State = DumpsterState.disabled.ToString(),
                Capacity = 20,
                Usage = 0,
                Location = new LocationData { X = 10, Y = 10 }
             }
        };
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
        public DumpsterData[] GetDumpsters()
        {
            return FakeDispatcher.dumpsters;
        }
        #endregion

        #region Measurements
        private static readonly MeasurementData[] measurements = new MeasurementData[]
        {
             new MeasurementData() {
                Id = "measurement2",
                DumpsterId = "dumpster1",
                DateTime = DateTime.Now.ToString(),
                Usage = 10,
             },
             new MeasurementData() {
                Id = "measurement3",
                DumpsterId = "dumpster2",
                DateTime= DateTime.MinValue.ToString(),
                Usage = 20
             }
        };
        public string DeleteMeasurement(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public MeasurementData[] GetMeasurements()
        {
            return FakeDispatcher.measurements;
        }
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            return FakeDispatcher.measurements.Where(measurement => DateTime.Parse(measurement.DateTime) <= dateTime).ToArray();
        }
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            return FakeDispatcher.measurements.Where(measurement => measurement.DumpsterId == id).ToArray();
        }
        #endregion

        #region Vehicles
        private static readonly VehicleData[] vehicles = new VehicleData[]
        {
            new VehicleData() {
                Id = "vehicle1",
                Brand = "Mercedes",
                Model = "Axor",
                Plate = "WWL",
                State = VehicleState.assigned.ToString(),
                Capacity = 20000,
                Load = 20000,
                Consumption = 30,
                Fuel = Fuel.H2.ToString(),
            },
            new VehicleData() {
                Id = "vehicle2",
                Brand = "Mercedes",
                Model = "Axor",
                Plate = "WWL",
                State = VehicleState.working.ToString(),
                Capacity = 22000,
                Load = 26000,
                Consumption = 40,
                Fuel = Fuel.ON.ToString(),
            }
        };
        public string AddVehicle(VehicleData vehicle)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string EditVehicle(VehicleData vehicle)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteVehicle(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public VehicleData[] GetVehicles()
        {
            return FakeDispatcher.vehicles;
        }
        #endregion

        #region Routes
        private static readonly RouteData[] routes = new RouteData[]
        {
            new RouteData() {
                Id = "route1",
                VehicleId = "vehicle1",
                DumpstersIds = new System.Collections.Generic.List<string>(){"dumpster1", "dumpster2"},
                State = RouteState.started.ToString(),
            },
            new RouteData() {
                Id = "route2",
                VehicleId = "vehicle2",
                DumpstersIds = new System.Collections.Generic.List<string>(){"dumpster2", "dumpster3"},
                State = RouteState.finished.ToString(),
            }
        };
        public string ChangeRouteState(string id, string state)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteRoute(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public RouteData[] GetRoutes()
        {
            return FakeDispatcher.routes.Where(r => r.State != RouteState.finished.ToString()).ToArray();
        }
        public RouteData[] GetOldRoutes()
        {
            return FakeDispatcher.routes;
        }

        public string StartRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }

        public string FinishRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }

        public string CalculateRoute()
        {
            throw new NotImplementedException();
        }

        public string DeleteRoute(RouteData routeData)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
