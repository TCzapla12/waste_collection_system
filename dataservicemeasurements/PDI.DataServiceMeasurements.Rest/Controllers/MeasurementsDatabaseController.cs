namespace PDI.DataServiceMeasurements.Rest
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.DataServiceMeasurements.Model;
    using PDI.DataServiceMeasurements.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class MeasurementsDatabaseController : ControllerBase, IMeasurementsDatabaseService, ITestsService
    {
        private readonly ILogger<MeasurementsDatabaseController> logger;

        private readonly IMeasurementsDatabase measurementsDatabase;

        public MeasurementsDatabaseController(IMeasurementsDatabase measurementsDatabase, ILogger<MeasurementsDatabaseController> logger)
        {
            this.logger = logger;

            this.measurementsDatabase = measurementsDatabase;
        }
        [HttpPost]
        [Route("AddMeasurement")]
        public string AddMeasurement(MeasurementData measurement)
        {
            measurement.Id = this.measurementsDatabase.GetNewId();

            return this.measurementsDatabase.AddMeasurement(measurement.ConvertToMeasurement());
        }
        [HttpDelete]
        [Route("DeleteMeasurement/{id}")]
        public string DeleteMeasurement(string id)
        {
            return this.measurementsDatabase.DeleteMeasurement(id);
        }
        [HttpDelete]
        [Route("DeleteOldMeasurements/{dateTime}")]
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            return this.measurementsDatabase.DeleteOldMeasurements(dateTime);
        }
        [HttpGet]
        [Route("GetMeasurements")]
        public MeasurementData[] GetMeasurements()
        {
            Measurement[] measurements = this.measurementsDatabase.GetMeasurements();

            return measurements.Select(measurenemt => measurenemt.ConvertToMeasurementData()).ToArray();
        }
        [HttpGet]
        [Route("GetOldMeasurements/{dateTime}")]
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            Measurement[] measurements = this.measurementsDatabase.GetOldMeasurements(dateTime);

            return measurements.Select(measurenemt => measurenemt.ConvertToMeasurementData()).ToArray();
        }
        [HttpGet]
        [Route("GetDumpsterMeasurements/{id}")]
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            Measurement[] measurements = this.measurementsDatabase.GetDumpsterMeasurements(id);

            return measurements.Select(measurenemt => measurenemt.ConvertToMeasurementData()).ToArray();
        }
        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.measurementsDatabase);

            return tests.RunTests(host, port);
        }
        [HttpPut]
        [Route("EmptyMeasurements")]
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            return this.measurementsDatabase.EmptyMeasurements(emptyMeasurements.Ids, DateTime.Parse(emptyMeasurements.DateTime));
        }
    }
}
