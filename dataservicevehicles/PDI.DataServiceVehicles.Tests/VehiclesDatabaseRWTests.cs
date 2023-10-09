namespace PDI.DataServiceVehicles.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System;

    using PDI.DataServiceVehicles.Model;

    [TestClass]
    public class VehiclesDatabaseRWTests
    {
        private const string vehiclesJsonFilename = "./../../../vehicles.json";

        [TestMethod]
        public void ReadVehicles_VehiclesDatabaseJsonFile_Returns2Vehicles()
        {
            IList<Vehicle> vehicles = VehiclesDatabaseReader.ReadVehicles(vehiclesJsonFilename);

            int count = vehicles.Count;

            Assert.AreEqual(2, count, "The child count of the document element should be {0} and not {1}", 2, count);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ReadJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => VehiclesDatabaseReader.ReadVehicles(jsonFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [DataTestMethod]
        [DataRow("")]
        public void WriteJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => VehiclesDatabaseWriter.WriteVehicles(jsonFilename, CreateDefaultFilesVehiclesList());

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void WriteVehicles_VehiclesDatabaseJsonFilename_Returns2Vehicles()
        {
            VehiclesDatabaseWriter.WriteVehicles(vehiclesJsonFilename, CreateDefaultFilesVehiclesList());

            int count = VehiclesDatabaseReader.ReadVehicles(vehiclesJsonFilename).Count;

            Assert.AreEqual(2, count, "Node count should be {0} and not {1}", 2, count);
        }

        private IList<Vehicle> CreateDefaultFilesVehiclesList()
        {
            return new Vehicle[] { new Vehicle("vehicle10", "Mercedes", "Axor", "WWL", State.enabled, 22000, 20000, 40, Fuel.ON),
                new Vehicle("vehicle11", "Mercedes", "Faun", "WWL", State.disabled, 20000, 26000, 50, Fuel.ON) };
        }
    }
}
