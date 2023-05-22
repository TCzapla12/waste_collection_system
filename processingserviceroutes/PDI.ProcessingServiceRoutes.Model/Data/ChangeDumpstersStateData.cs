using System.Collections.Generic;

namespace PDI.ProcessingServiceRoutes.Model
{
    public class ChangeDumpstersStateData
    {
        public List<string> Ids { get; set; }
        public string State { get; set; }
    }
}
