using System;

namespace PDI.AppServiceDispatcher.Model
{
    public interface IMeasurementsClient
    {
        public string DeleteMeasurement(string id);
        public string DeleteOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetMeasurements();
        public MeasurementData[] GetOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetDumpsterMeasurements(string id);
    }
}
