namespace PDI.AppServiceDispatcher.Rest
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.AppServiceDispatcher.Model;
    using PDI.AppServiceDispatcher.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class DispatcherController : ControllerBase, IDispatcherService, ITestsService
    {
        private readonly ILogger<DispatcherController> logger;

        private readonly IDispatcher dispatcher;

        public DispatcherController(IDispatcher dispatcher, ILogger<DispatcherController> logger)
        {
            this.logger = logger;

            this.dispatcher = dispatcher;
        }

        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port, string dataService)
        {
            ITestsService tests = new Tests.Tests(this.dispatcher);

            return tests.RunTests(host, port, dataService);
        }

        #region Dumpsters
        [HttpPost]
        [Route("AddDumpster")]
        public string AddDumpster(DumpsterData dumpster)
        {
            return this.dispatcher.AddDumpster(dumpster);
        }
        [HttpPut]
        [Route("EditDumpster")]
        public string EditDumpster(DumpsterData dumpster)
        {
            return this.dispatcher.EditDumpster(dumpster);
        }
        [HttpDelete]
        [Route("DeleteDumpster/{id}")]
        public string DeleteDumpster(string id)
        {
            return this.dispatcher.DeleteDumpster(id);
        }
        [HttpGet]
        [Route("GetDumpsters")]
        public DumpsterData[] GetDumpsters()
        {
            return this.dispatcher.GetDumpsters();
        }
        #endregion

        #region Measurements
        [HttpDelete]
        [Route("DeleteMeasurement/{id}")]
        public string DeleteMeasurement(string id)
        {
            return this.dispatcher.DeleteMeasurement(id);
        }
        [HttpDelete]
        [Route("DeleteOldMeasurements/{dateTime}")]
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            return this.dispatcher.DeleteOldMeasurements(dateTime);
        }
        [HttpGet]
        [Route("GetMeasurements")]
        public MeasurementData[] GetMeasurements()
        {
            return this.dispatcher.GetMeasurements();
        }
        [HttpGet]
        [Route("GetOldMeasurements/{dateTime}")]
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            return this.dispatcher.GetOldMeasurements(dateTime);
        }
        [HttpGet]
        [Route("GetDumpsterMeasurements/{id}")]
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            return this.dispatcher.GetDumpsterMeasurements(id);
        }
        #endregion

        #region Vehicles
        [HttpPost]
        [Route("AddVehicle")]
        public string AddVehicle(VehicleData vehicle)
        {
            return this.dispatcher.AddVehicle(vehicle);
        }
        [HttpPut]
        [Route("EditVehicle")]
        public string EditVehicle(VehicleData vehicle)
        {
            return this.dispatcher.EditVehicle(vehicle);
        }
        [HttpDelete]
        [Route("DeleteVehicle/{id}")]
        public string DeleteVehicle(string id)
        {
            return this.dispatcher.DeleteVehicle(id);
        }
        [HttpGet]
        [Route("GetVehicles")]
        public VehicleData[] GetVehicles()
        {
            return this.dispatcher.GetVehicles();
        }
        #endregion

        #region Routes
        [HttpPut]
        [Route("StartRoute")]
        public string StartRoute(RouteData routeData)
        {
            return this.dispatcher.StartRoute(routeData);
        }
        [HttpPut]
        [Route("FinishRoute")]
        public string FinishRoute(RouteData routeData)
        {
            return this.dispatcher.FinishRoute(routeData);
        }
        [HttpPost]
        [Route("CalculateRoute")]
        public string CalculateRoute()
        {
            return this.dispatcher.CalculateRoute();
        }
        [HttpDelete]
        [Route("DeleteRoute")]
        public string DeleteRoute(RouteData routeData)
        {
            return this.dispatcher.DeleteRoute(routeData);
        }
        [HttpGet]
        [Route("GetRoutes")]
        public RouteData[] GetRoutes()
        {
            return this.dispatcher.GetRoutes();
        }
        [HttpGet]
        [Route("GetOldRoutes")]
        public RouteData[] GetOldRoutes()
        {
            return this.dispatcher.GetOldRoutes();
        }
        #endregion
    }
}
