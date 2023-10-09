namespace PDI.DataServiceDumpsters.Model
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System;
    using System.Text.Json;

    public class DumpstersDatabaseWriter
    {
        public static void WriteDumpsters(string jsonFilename, IList<Dumpster> dumpsters)
        {
            if (String.IsNullOrWhiteSpace(jsonFilename))
                throw new ArgumentException();

            Debug.Assert(jsonFilename != null);

            Debug.Assert(condition: dumpsters != null);

            using FileStream openStream = File.Open(jsonFilename, FileMode.Create);

            Debug.Assert(condition: openStream != null);

            JsonSerializer.Serialize(openStream, dumpsters);
        }
    }
}
