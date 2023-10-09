using System.Collections.Generic;

namespace PDI.AppServiceDispatcher.Model
{
    public interface IDumpstersClient
    {
        public string AddDumpster(DumpsterData dumpster);
        public string EditDumpster(DumpsterData dumpster);
        public string DeleteDumpster(string id);
        public string ChangeDumpstersState(List<string> ids, string state);
        public DumpsterData[] GetDumpsters();
    }
}
