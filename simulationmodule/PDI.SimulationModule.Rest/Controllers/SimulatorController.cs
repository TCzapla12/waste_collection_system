namespace PDI.SimulationModule.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.SimulationModule.Model;
    using PDI.SimulationModule.Rest.Model;
    using System;
    using PDI.SimulationModule.Logic;

    [ApiController]
    [Route("[controller]")]
    public class SimulatorController : ControllerBase, ISimulatorService, ITestsService
    {
        private readonly ILogger<SimulatorController> logger;

        private readonly ISimulator simulator;

        public SimulatorController(ISimulator simulator, ILogger<SimulatorController> logger)
        {
            this.logger = logger;

            this.simulator = simulator;
        }

        [HttpPut]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            //ITestsService tests = new Tests.Tests(this.sensor);

            //return tests.RunTests(host, port);
            throw new NotImplementedException();
        }

        [HttpPut]
        [Route("ChangeSimulationState/{state}")]
        public string ChangeSimulationState(string state)
        {
            Console.WriteLine("[Zmiana w bazie danych]");
            return this.simulator.ChangeSimulationState((SimulationState)Enum.Parse(typeof(SimulationState),state));
        }
        [HttpPut]
        [Route("EmptyDumpsters")]
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            Console.WriteLine("[Zakończono trasę]"); 
            return this.simulator.EmptyDumpsters(emptyDumpsters);
        }

    }
}
