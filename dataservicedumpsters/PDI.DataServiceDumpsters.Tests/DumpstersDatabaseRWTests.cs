namespace PDI.DataServiceDumpsters.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PDI.DataServiceDumpsters.Model;

    [TestClass]
    public class DumpstersDatabaseRWTests
    {
        private const string dumpstersJsonFilename = "./../../../dumpsters.json";

        [TestMethod]
        public void ReadDumpsters_DumpstersDatabaseJsonFile_Returns2Dumpsters()
        {
            IList<Dumpster> dumpsters = DumpstersDatabaseReader.ReadDumpsters(dumpstersJsonFilename);

            int count = dumpsters.Count;

            Assert.AreEqual(2, count, "The child count of the document element should be {0} and not {1}", 2, count);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ReadJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => DumpstersDatabaseReader.ReadDumpsters(jsonFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [DataTestMethod]
        [DataRow("")]
        public void WriteJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => DumpstersDatabaseWriter.WriteDumpsters(jsonFilename, CreateDefaultFilesDumpstersList());

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void WriteDumpsters_DumpstersDatabaseJsonFile_Returns2Dumpsters()
        {
            DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, CreateDefaultFilesDumpstersList());

            int count = DumpstersDatabaseReader.ReadDumpsters(dumpstersJsonFilename).Count;

            Assert.AreEqual(2, count, "Dumpsters count should be {0} and not {1}", 2, count);
        }

        private IList<Dumpster> CreateDefaultFilesDumpstersList()
        {
            return new Dumpster[] { new Dumpster("dumpster10", State.enabled, 120, 90, new Location(0,0)),
                new Dumpster("dumpster11", State.assigned, 240, 50, new Location(10,10)) };
        }
    }
}
