namespace PDI.DataServiceVehicles.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    public class VehiclesDatabaseReader
    {
        public static IList<Vehicle> ReadVehicles(string jsonFilename)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            using FileStream openStream = File.OpenRead(jsonFilename);

            Debug.Assert(condition: openStream != null);

            List<Vehicle> vehicles = JsonSerializer.Deserialize<List<Vehicle>>(openStream);

            Debug.Assert(condition: vehicles != null);

            return vehicles;
        }
    }
}
