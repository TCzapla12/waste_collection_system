using System.Collections.Generic;

namespace PDI.DataServiceDumpsters.Rest.Model
{
    public class ChangeStateData
    {
        public List<string> Ids { get; set; }
        public string State { get; set; }
    }
}
