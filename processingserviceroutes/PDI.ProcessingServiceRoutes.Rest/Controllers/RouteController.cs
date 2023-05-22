namespace PDI.ProcessingServiceRoutes.Rest
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PDI.ProcessingServiceRoutes.Model;
    using PDI.ProcessingServiceRoutes.Rest.Model;

    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase, IRouteService, ITestsService
    {
        private readonly ILogger<RouteController> logger;

        private readonly IRoute route;

        public RouteController(IRoute route, ILogger<RouteController> logger)
        {
            this.logger = logger;

            this.route = route;
        }

        [HttpPost]
        [Route("CalculateRoute")]
        public string CalculateRoute()
        {
            return this.route.CalculateRoute();
        }

        [HttpGet]
        [Route("RunTests")]
        public string RunTests(string host, int port)
        {
            ITestsService tests = new Tests.Tests(this.route);

            return tests.RunTests(host, port);
        }
    }
}
