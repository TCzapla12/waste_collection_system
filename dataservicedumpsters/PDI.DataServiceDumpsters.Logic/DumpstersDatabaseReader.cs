namespace PDI.DataServiceDumpsters.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    public class DumpstersDatabaseReader
    {
        public static IList<Dumpster> ReadDumpsters(string jsonFilename)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            using FileStream openStream = File.OpenRead(jsonFilename);

            Debug.Assert(condition: openStream != null);

            List<Dumpster> dumpsters = JsonSerializer.Deserialize<List<Dumpster>>(openStream);

            Debug.Assert(condition: dumpsters != null);

            return dumpsters;
        }
    }
}
