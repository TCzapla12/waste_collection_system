namespace PDI.DataServiceRoutes.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using PDI.DataServiceRoutes.Model;
    using System.Collections.Generic;
    using System;

    [TestClass]
    public class RoutesDatabaseRWTests
    {
        private const string routesJsonFilename = "./../../../routes.json";

        [TestMethod]
        public void ReadRoutes_RoutesDatabaseJsonFile_Returns2Routes()
        {
            IList<Route> routes = RoutesDatabaseReader.ReadRoutes(routesJsonFilename);

            int count = routes.Count;

            Assert.AreEqual(2, count, "The child count of the document element should be {0} and not {1}", 2, count);
        }

        [DataTestMethod]
        [DataRow("")]
        public void ReadJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => RoutesDatabaseReader.ReadRoutes(jsonFilename);

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [DataTestMethod]
        [DataRow("")]
        public void WriteJsonDocument_EmptyFilename_ThrowsArgumentException(string jsonFilename)
        {
            Action action = () => RoutesDatabaseWriter.WriteRoutes(jsonFilename, CreateDefaultFilesRoutesList());

            Assert.ThrowsException<ArgumentException>(action, "Should throw ArgumentException on empty filenames");
        }

        [TestMethod]
        public void WriteRoutes_RoutesDatabaseJsonFilename_Returns2Routes()
        {
            RoutesDatabaseWriter.WriteRoutes(routesJsonFilename, CreateDefaultFilesRoutesList());

            int count = RoutesDatabaseReader.ReadRoutes(routesJsonFilename).Count;

            Assert.AreEqual(2, count, "Node count should be {0} and not {1}", 2, count);
        }

        private IList<Route> CreateDefaultFilesRoutesList()
        {
            return new Route[] { new Route("route10", "vehicle10", new List<string>() { "dumpster10", "dumpster20" },
                State.started, 1.123, DateTime.Parse("2018-04-23T13:06:43"),DateTime.Parse("2018-04-23T13:44:43"),DateTime.Parse("2000-04-23T13:20:43")),
                new Route("route11", "vehicle", new List<string>() { "dumpster11", "dumpster21" },
                State.notStarted, 0.256,DateTime.Parse("2018-04-23T13:20:43"),DateTime.Parse("2000-04-23T13:20:43"),DateTime.Parse("2000-04-23T13:20:43")) };
        }
    }
}
