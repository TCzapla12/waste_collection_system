namespace PDI.DataServiceRoutes.Rest.Model
{
    using PDI.DataServiceRoutes.Model;
    using System;

    public static class DataConverter
    {
        public static RouteData ConvertToRouteData(this Route route)
        {
            return new RouteData()
            {
                Id = route.Id,
                VehicleId = route.VehicleId,
                DumpstersIds = route.DumpstersIds,
                State = route.State.ToString(),
                Distance = route.Distance,
                CreateDate = route.CreateDate.ToString(),
                StartDate = route.StartDate.ToString(),
                FinishDate = route.FinishDate.ToString()
            };
        }

        public static Route ConvertToRoute(this RouteData routeData)
        {
            return new Route(
                routeData.Id,
                routeData.VehicleId,
                routeData.DumpstersIds,
                (State)Enum.Parse(typeof(State), 
                routeData.State),
                routeData.Distance,
                DateTime.Parse(routeData.CreateDate),
                DateTime.Parse(routeData.StartDate),
                DateTime.Parse(routeData.FinishDate));
        }
    }
}
