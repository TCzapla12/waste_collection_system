namespace PDI.ProcessingServiceSensors.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.ProcessingServiceSensors.Model;
    using PDI.ProcessingServiceSensors.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class SensorController : ControllerBase, ISensorService, ITestsService
    {
        private readonly ILogger<SensorController> logger;

        private readonly ISensor sensor;

        public SensorController(ISensor sensor, ILogger<SensorController> logger)
        {
            this.logger = logger;

            this.sensor = sensor;
        }

        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.sensor);

            return tests.RunTests(host, port);
        }

        [HttpPost]
        [Route("AddData")]
        public string AddData(MeasurementData measurement)
        {
            return this.sensor.AddData(measurement);
        }

        [HttpGet]
        [Route("GetDumpsters")]
        public DumpsterData[] GetDumpsters()
        {
            return this.sensor.GetDumpsters();
        }

        [HttpPut]
        [Route("EmptyMeasurements")]
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            return this.sensor.EmptyMeasurements(emptyMeasurements);
        }
    }
}
