namespace PDI.DataServiceDumpsters.Model
{
    using System.Collections.Generic;
    public interface IDumpstersDatabase
    {
        public string AddDumpster(Dumpster dumpster);
        public string EditDumpster(Dumpster dumpster);
        public string ChangeDumpsterUsage(string id, int usage);
        public string ChangeDumpstersState(List<string> ids, State state);
        public string DeleteDumpster(string id);
        public Dumpster[] GetDumpsters();
        public string GetNewId();
        public string EmptyDumpsters(List<string> ids);
    }
}
