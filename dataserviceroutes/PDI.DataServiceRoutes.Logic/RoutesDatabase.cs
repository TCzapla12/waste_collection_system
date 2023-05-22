namespace PDI.DataServiceRoutes.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PDI.DataServiceRoutes.Model;
    public class RoutesDatabase : IRoutesDatabase
    {
        private const string routesJsonFilename = "routes.json";

        private static readonly IList<Route> Routes = new List<Route>();

        private static readonly object routesLock = new ();

        static RoutesDatabase()
        {
            lock (RoutesDatabase.routesLock)
            {
                RoutesDatabase.Routes = RoutesDatabaseReader.ReadRoutes(routesJsonFilename);
            }
        }

        public RoutesDatabase()
        {
        }
        public string AddRoute(Route route)
        {
            lock (RoutesDatabase.routesLock)
            {
                RoutesDatabase.Routes.Add(route);

                RoutesDatabaseWriter.WriteRoutes(routesJsonFilename, RoutesDatabase.Routes);

                return Message.GetMessage(MessageEnum.success);
            }
        }

        public string EditRoute(Route route)
        {
            string searchId = route.Id;

            lock (RoutesDatabase.routesLock)
            {
               for(int i = 0; i < RoutesDatabase.Routes.Count; i++)
                {
                    if(RoutesDatabase.Routes[i].Id == searchId)
                    {
                        if (RoutesDatabase.Routes[i].State != State.notStarted)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        RoutesDatabase.Routes[i] = route;

                        RoutesDatabaseWriter.WriteRoutes(routesJsonFilename, RoutesDatabase.Routes);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }

        public string ChangeRouteState(string id, State state)
        {
            lock (RoutesDatabase.routesLock)
            {
                for(int i = 0; i < RoutesDatabase.Routes.Count; i++)
                {
                    if (RoutesDatabase.Routes[i].Id == id)
                    {
                        if (RoutesDatabase.Routes[i].State == state)
                        {
                            return Message.GetMessage(MessageEnum.sameState);
                        }
                        else if (RoutesDatabase.Routes[i].State == State.notStarted && state != State.started ||
                            RoutesDatabase.Routes[i].State == State.started && state != State.finished ||
                            RoutesDatabase.Routes[i].State == State.finished)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }

                        RoutesDatabase.Routes[i].SetState(state);

                        RoutesDatabaseWriter.WriteRoutes(routesJsonFilename, RoutesDatabase.Routes);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public string DeleteRoute(string id)
        {
            lock (RoutesDatabase.routesLock)
            {
                for (int i = 0; i < RoutesDatabase.Routes.Count; i++)
                {
                    if (RoutesDatabase.Routes[i].Id == id)
                    {
                        if (RoutesDatabase.Routes[i].State == State.started)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        RoutesDatabase.Routes.RemoveAt(i);

                        RoutesDatabaseWriter.WriteRoutes(routesJsonFilename, RoutesDatabase.Routes);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }

        public Route[] GetRoutes()
        {
            lock (RoutesDatabase.routesLock)
            {
                return RoutesDatabase.Routes.Where(r => r.State != State.finished).ToArray();
            }
        }

        public Route[] GetOldRoutes()
        {
            lock (RoutesDatabase.routesLock)
            {
                return RoutesDatabase.Routes.ToArray();
            }
        }

        public string GetNewId()
        {
            lock(RoutesDatabase.routesLock)
            {
                if(RoutesDatabase.Routes.Count == 0)
                {
                    return "0";
                }
                else return (int.Parse(RoutesDatabase.Routes.Last().Id) + 1).ToString();
            }
        }
    }
}
