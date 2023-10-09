namespace PDI.DataServiceDumpsters.Logic
{
    using PDI.DataServiceDumpsters.Model;
    using System.Collections.Generic;

    public class FakeDumpstersDatabase : IDumpstersDatabase
    {
        private static readonly Dumpster[] dumpsters = new Dumpster[]
        { 
            new Dumpster("dumpster1", State.enabled, 10, 100, new Location(0, 0)),
            new Dumpster("dumpster2", State.disabled, 20, 0, new Location(10, 10))
        };
        public FakeDumpstersDatabase()
        {
        }

        public string AddDumpster(Dumpster dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string EditDumpster(Dumpster dumpster)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string ChangeDumpsterUsage(string id, int usage)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string ChangeDumpstersState(List<string> ids, State state)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteDumpster(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public Dumpster[] GetDumpsters()
        {
            return FakeDumpstersDatabase.dumpsters;
        }
        public string GetNewId()
        {
            return "1";
        }
        public string EmptyDumpsters(List<string> ids)
        {
            return Message.GetMessage(MessageEnum.success);
        }
    }
}
