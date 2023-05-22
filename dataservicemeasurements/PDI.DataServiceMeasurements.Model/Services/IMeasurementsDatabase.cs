namespace PDI.DataServiceMeasurements.Model
{
    using System;
    using System.Collections.Generic;
    public interface IMeasurementsDatabase
    {
        public string AddMeasurement(Measurement measurement);
        public string DeleteMeasurement(string id);
        public string DeleteOldMeasurements(DateTime dateTime);
        public Measurement[] GetMeasurements();
        public Measurement[] GetOldMeasurements(DateTime dateTime);
        public Measurement[] GetDumpsterMeasurements(string id);
        public string GetNewId();
        public string EmptyMeasurements(List<string> ids, DateTime dateTime);
    }
}
