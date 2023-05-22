namespace PDI.ProcessingServiceRoutes.Model
{
    public interface IRoutesClient
    {
        public string ChangeRouteState(string id, string state);
        public string AddRoute(RouteData route);
        public string EditRoute(RouteData route);
        public string DeleteRoute(string id);
        public RouteData[] GetRoutes();
    }
}
