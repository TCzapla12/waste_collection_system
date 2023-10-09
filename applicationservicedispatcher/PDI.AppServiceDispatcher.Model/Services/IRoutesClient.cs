namespace PDI.AppServiceDispatcher.Model
{
    public interface IRoutesClient
    {
        public string ChangeRouteState(string id, string state);
        public string DeleteRoute(string id);
        public RouteData[] GetRoutes();
        public RouteData[] GetOldRoutes();
    }
}
