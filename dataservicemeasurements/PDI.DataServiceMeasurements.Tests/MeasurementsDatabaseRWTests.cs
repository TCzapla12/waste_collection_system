namespace PDI.DataServiceMeasurements.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PDI.DataServiceMeasurements.Model;

    [TestClass]
    public class MeasurementsDatabaseRWTests
    {
        private const string measurementsJsonFilename = "./../../../measurements.json";

        [TestMethod]
        public void ReadMeasurements_MeasurementsDatabaseJsonFile_Returns2Measurements()
        {
            IList<Measurement> measurements = MeasurementsDatabaseReader.ReadMeasurements(measurementsJsonFilename);

            int count = measurements.Count;

            Assert.AreEqual(2, count, "The child count of the document element should be {0} and not {1}", 2, count);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ReadJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => MeasurementsDatabaseReader.ReadMeasurements(jsonFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [DataTestMethod]
        [DataRow("")]
        public void WriteJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => MeasurementsDatabaseWriter.WriteMeasurements(jsonFilename, CreateDefaultFilesMeasurementsList());

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void WriteMeasurements_MeasurementsDatabaseJsonFile_Returns2Measurements()
        {
            MeasurementsDatabaseWriter.WriteMeasurements(measurementsJsonFilename, CreateDefaultFilesMeasurementsList());

            int count = MeasurementsDatabaseReader.ReadMeasurements(measurementsJsonFilename).Count;

            Assert.AreEqual(2, count, "Measurements count should be {0} and not {1}", 2, count);
        }

        private IList<Measurement> CreateDefaultFilesMeasurementsList()
        {
            return new Measurement[] { new Measurement("measurement10", "dumpster1", DateTime.Now, 10), new Measurement("measurement11", "dumpster2", DateTime.MinValue, 20) };
        }
    }
}
