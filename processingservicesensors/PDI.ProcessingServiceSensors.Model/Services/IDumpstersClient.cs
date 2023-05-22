namespace PDI.ProcessingServiceSensors.Model
{
    public interface IDumpstersClient
    {
        public string ChangeDumpsterUsage(string id, int usage);
        public DumpsterData[] GetDumpsters();
        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters);
    }
}
