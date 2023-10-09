namespace PDI.DataServiceRoutes.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    public class RoutesDatabaseReader
    {
        public static IList<Route> ReadRoutes(string jsonFilename)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            using FileStream openStream = File.OpenRead(jsonFilename);

            Debug.Assert(condition: openStream != null);

            List<Route> routes = JsonSerializer.Deserialize<List<Route>>(openStream);

            Debug.Assert(condition: routes != null);

            return routes;
        }
    }
}
