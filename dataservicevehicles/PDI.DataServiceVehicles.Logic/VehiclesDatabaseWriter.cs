namespace PDI.DataServiceVehicles.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System;
    using System.Text.Json;
    
    public class VehiclesDatabaseWriter
    {
        public static void WriteVehicles(string jsonFilename, IList<Vehicle> vehicles)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            Debug.Assert(condition: vehicles != null);

            using FileStream openStream = File.Open(jsonFilename, FileMode.Create);

            Debug.Assert(condition: openStream != null);

            JsonSerializer.Serialize(openStream, vehicles);
        }
    }
}
