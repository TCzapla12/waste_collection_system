namespace PDI.DataServiceMeasurements.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PDI.DataServiceMeasurements.Model;

    public class FakeMeasurementsDatabase : IMeasurementsDatabase
    {
        private static readonly Measurement[] measurements = new Measurement[] 
        { 
            new Measurement("measurement2", "dumpster1", DateTime.Now, 10), 
            new Measurement("measurement3", "dumpster2", DateTime.MinValue, 20) 
        };
        public FakeMeasurementsDatabase()
        {
        }

        public string AddMeasurement(Measurement measurement)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteMeasurement(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public Measurement[] GetMeasurements()
        {
            return FakeMeasurementsDatabase.measurements;
        }
        public Measurement[] GetOldMeasurements(DateTime dateTime)
        {
            return FakeMeasurementsDatabase.measurements.Where(measurement => measurement.DateTime <= dateTime).ToArray();
        }
        public Measurement[] GetDumpsterMeasurements(string id)
        {
            return FakeMeasurementsDatabase.measurements.Where(measurement => measurement.DumpsterId == id).ToArray();
        }
        public string GetNewId()
        {
            return "1";
        }
        public string EmptyMeasurements(List<string> ids, DateTime dateTime)
        {
            return Message.GetMessage(MessageEnum.success);
        }
    }
}
