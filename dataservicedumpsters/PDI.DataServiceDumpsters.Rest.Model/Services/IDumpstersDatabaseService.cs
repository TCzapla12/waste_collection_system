namespace PDI.DataServiceDumpsters.Rest.Model
{
    public interface IDumpstersDatabaseService
    {
        public string AddDumpster(DumpsterData dumpster);
        public string EditDumpster(DumpsterData dumpster);
        public string ChangeDumpsterUsage(string id, int usage);
        public string ChangeDumpstersState(ChangeStateData data);
        public string DeleteDumpster(string id);
        public DumpsterData[] GetDumpsters();
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters);
    }
}
