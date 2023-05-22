namespace PDI.DataServiceRoutes.Rest.Model
{
  public interface IRoutesDatabaseService
  {
        public string AddRoute(RouteData route);
        public string EditRoute(RouteData route);
        public string ChangeRouteState(string id, string state);
        public string DeleteRoute(string id);
        public RouteData[] GetRoutes();
        public RouteData[] GetOldRoutes();
    }
}
