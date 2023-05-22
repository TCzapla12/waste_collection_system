namespace PDI.DataServiceMeasurements.Rest.Model
{
    using PDI.DataServiceMeasurements.Model;
    using System;

    public static class DataConverter
    {
        public static MeasurementData ConvertToMeasurementData(this Measurement measurement)
        {
            return new MeasurementData()
            {
                Id = measurement.Id,
                DumpsterId = measurement.DumpsterId,
                DateTime = measurement.DateTime.ToString(),
                Usage = measurement.Usage,
            };
        }
        public static Measurement ConvertToMeasurement(this MeasurementData measurementData)
        {
            return new Measurement(
                measurementData.Id,
                measurementData.DumpsterId,
                DateTime.Parse(measurementData.DateTime),
                measurementData.Usage);
        }
    }
}
