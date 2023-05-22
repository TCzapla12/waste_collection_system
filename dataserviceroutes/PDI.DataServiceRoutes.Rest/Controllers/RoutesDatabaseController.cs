namespace PDI.DataServiceRoutes.Rest
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.DataServiceRoutes.Model;
    using PDI.DataServiceRoutes.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class RoutesDatabaseController : ControllerBase, IRoutesDatabaseService, ITestsService
    {
        private readonly ILogger<RoutesDatabaseController> logger;

        private readonly IRoutesDatabase routesDatabase;

        public RoutesDatabaseController(IRoutesDatabase routesDatabase, ILogger<RoutesDatabaseController> logger)
        {
            this.logger = logger;

            this.routesDatabase = routesDatabase;
        }

        [HttpPost]
        [Route("AddRoute")]
        public string AddRoute(RouteData route)
        {
            route.Id = this.routesDatabase.GetNewId();

            return this.routesDatabase.AddRoute(route.ConvertToRoute());
        }
        [HttpPut]
        [Route("EditRoute")]
        public string EditRoute(RouteData route)
        {
            return this.routesDatabase.EditRoute(route.ConvertToRoute());
        }
        [HttpPut]
        [Route("ChangeRouteState/{id}")]
        public string ChangeRouteState(string id, string state)
        {
            return this.routesDatabase.ChangeRouteState(id, (State)Enum.Parse(typeof(State), state));
        }
        [HttpDelete]
        [Route("DeleteRoute/{id}")]
        public string DeleteRoute(string id)
        {
            return this.routesDatabase.DeleteRoute(id);
        }
        [HttpGet]
        [Route("GetRoutes")]
        public RouteData[] GetRoutes()
        {
            Route[] routes = this.routesDatabase.GetRoutes();

            return routes.Select(route => route.ConvertToRouteData()).ToArray();
        }
        [HttpGet]
        [Route("GetOldRoutes")]
        public RouteData[] GetOldRoutes()
        {
            Route[] routes = this.routesDatabase.GetOldRoutes();

            return routes.Select(route => route.ConvertToRouteData()).ToArray();
        }
        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.routesDatabase);

            return tests.RunTests(host, port);
        }
    }
}
