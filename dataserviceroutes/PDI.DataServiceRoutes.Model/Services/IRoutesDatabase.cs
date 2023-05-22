namespace PDI.DataServiceRoutes.Model
{
    public interface IRoutesDatabase
    {
        public string AddRoute(Route route);
        public string EditRoute(Route route);
        public string ChangeRouteState(string id, State state);
        public string DeleteRoute(string id);
        public Route[] GetRoutes();
        public Route[] GetOldRoutes();
        public string GetNewId();
    }
}
