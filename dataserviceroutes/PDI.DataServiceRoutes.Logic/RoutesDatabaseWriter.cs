namespace PDI.DataServiceRoutes.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System;
    using System.Text.Json;
    public class RoutesDatabaseWriter
    {
        public static void WriteRoutes(string jsonFilename, IList<Route> routes)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            Debug.Assert(condition: routes != null);

            using FileStream openStream = File.Open(jsonFilename, FileMode.Create);

            Debug.Assert(condition: openStream != null);

            JsonSerializer.Serialize(openStream, routes);
        }
    }
}
