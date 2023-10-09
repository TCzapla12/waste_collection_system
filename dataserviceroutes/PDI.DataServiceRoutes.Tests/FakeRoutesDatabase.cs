namespace PDI.DataServiceRoutes.Logic
{
    using PDI.DataServiceRoutes.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FakeRoutesDatabase : IRoutesDatabase
    {
        private static readonly Route[] routes = new Route[]
        {
            new Route("route1", "vehicle1",new List<string>(){"dumpster1", "dumpster2" },
                State.started, 1.746, DateTime.Now, DateTime.MinValue, DateTime.MinValue),
            new Route("route2", "vehicle2", new List<string>() {"dumpster2", "dumpster3"}, 
                State.notStarted, 2.747, DateTime.Parse("2018-04-23T18:20:43"), DateTime.Now, DateTime.MinValue),
            new Route("route3", "vehicle3", new List<string>() {"dumpster1", "dumpster2"}, 
                State.finished, 2.685, DateTime.Parse("2018-04-23T13:20:43"), DateTime.Parse("2018-04-23T13:50:43"), DateTime.Now)
        };
        public FakeRoutesDatabase()
        {
        }

        public string AddRoute(Route dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string EditRoute(Route dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string ChangeRouteState(string id, State state)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string DeleteRoute(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public Route[] GetRoutes()
        {
            return FakeRoutesDatabase.routes.Where(r => r.State != State.finished).ToArray();
        }
        public Route[] GetOldRoutes()
        {
            return FakeRoutesDatabase.routes;
        }
        public string GetNewId()
        {
            return "1";
        }
    }
}
