namespace PDI.DataServiceMeasurements.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    public class MeasurementsDatabaseReader
    {
        public static IList<Measurement> ReadMeasurements(string jsonFilename)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            using FileStream openStream = File.OpenRead(jsonFilename);

            Debug.Assert(condition: openStream != null);

            List<Measurement> measurements = JsonSerializer.Deserialize<List<Measurement>>(openStream);

            Debug.Assert(condition: measurements != null);

            return measurements;
        }
    }
}
