using System.Collections.Generic;

namespace PDI.ProcessingServiceRoutes.Model
{
    public interface IDumpstersClient
    {
        public string ChangeDumpstersState(List<string> ids, string state);
        public DumpsterData[] GetDumpsters();
    }
}
