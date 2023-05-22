namespace PDI.DataServiceMeasurements.Rest.Model
{
    using System;
    public interface IMeasurementsDatabaseService
    {
        public string AddMeasurement(MeasurementData measurement);
        public string DeleteMeasurement(string id);
        public string DeleteOldMeasurements(DateTime dateTime);
        public MeasurementData[] GetMeasurements();
        public MeasurementData[] GetOldMeasurements(DateTime dateTime);
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements);
    }
}
