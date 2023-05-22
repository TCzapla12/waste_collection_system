namespace PDI.DataServiceMeasurements.Model
{
    using System;
    public class Measurement : Object
    {
        public string DumpsterId { get; private set; }
        public DateTime DateTime { get; private set; }
        public int Usage { get; private set; }
        public Measurement(string id, string dumpsterId, DateTime dateTime, int usage): base(id)
        {
            DumpsterId = dumpsterId;
            DateTime = dateTime;
            Usage = usage;
        }
    }
}
