namespace PDI.DataServiceVehicles.Rest
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.DataServiceVehicles.Model;
    using PDI.DataServiceVehicles.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class VehiclesDatabaseController : ControllerBase, IVehiclesDatabaseService, ITestsService
    {
        private readonly ILogger<VehiclesDatabaseController> logger;

        private readonly IVehiclesDatabase vehiclesDatabase;

        public VehiclesDatabaseController(IVehiclesDatabase vehiclesDatabase, ILogger<VehiclesDatabaseController> logger)
        {
            this.logger = logger;

            this.vehiclesDatabase = vehiclesDatabase;
        }

        [HttpPost]
        [Route("AddVehicle")]
        public string AddVehicle(VehicleData vehicle)
        {
            vehicle.Id = this.vehiclesDatabase.GetNewId();

            return this.vehiclesDatabase.AddVehicle(vehicle.ConvertToVehicle());
        }
        [HttpPut]
        [Route("EditVehicle")]
        public string EditVehicle(VehicleData vehicle)
        {
            return this.vehiclesDatabase.EditVehicle(vehicle.ConvertToVehicle());
        }
        [HttpPut]
        [Route("ChangeVehicleState/{id}")]
        public string ChangeVehicleState(string id, string state)
        {
            return this.vehiclesDatabase.ChangeVehicleState(id, (State)Enum.Parse(typeof(State), state));
        }
        [HttpDelete]
        [Route("DeleteVehicle/{id}")]
        public string DeleteVehicle(string id)
        {
            return this.vehiclesDatabase.DeleteVehicle(id);
        }
        [HttpGet]
        [Route("GetVehicles")]
        public VehicleData[] GetVehicles()
        {
            Vehicle[] vehicles = this.vehiclesDatabase.GetVehicles();

            return vehicles.Select(vehicle => vehicle.ConvertToVehicleData()).ToArray();
        }
        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.vehiclesDatabase);

            return tests.RunTests(host, port);
        }
    }
}
