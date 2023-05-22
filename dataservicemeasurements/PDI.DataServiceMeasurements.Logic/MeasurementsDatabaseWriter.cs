namespace PDI.DataServiceMeasurements.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System;
    using System.Text.Json;

    public class MeasurementsDatabaseWriter
    {
        public static void WriteMeasurements(string jsonFilename, IList<Measurement> measurements)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            Debug.Assert(condition: measurements != null);

            using FileStream openStream = File.Open(jsonFilename, FileMode.Create);

            Debug.Assert(condition: openStream != null);

            JsonSerializer.Serialize(openStream, measurements);
        }
    }
}
