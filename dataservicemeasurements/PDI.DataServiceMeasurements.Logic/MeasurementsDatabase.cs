namespace PDI.DataServiceMeasurements.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Metrics;
    using System.Linq;
    using PDI.DataServiceMeasurements.Model;
    public class MeasurementsDatabase : IMeasurementsDatabase
    {
        private const string measurementsJsonFilename = "measurements.json";

        private static readonly IList<Measurement> Measurements = new List<Measurement>();

        private static readonly object measurementsLock = new();

        static MeasurementsDatabase()
        {
            lock (MeasurementsDatabase.measurementsLock)
            {
                MeasurementsDatabase.Measurements = MeasurementsDatabaseReader.ReadMeasurements(measurementsJsonFilename);
            }
        }
        public MeasurementsDatabase()
        {
        }
        public string AddMeasurement(Measurement measurement)
        {
            lock (MeasurementsDatabase.measurementsLock)
            {
                MeasurementsDatabase.Measurements.Add(measurement);

                MeasurementsDatabaseWriter.WriteMeasurements(measurementsJsonFilename, MeasurementsDatabase.Measurements);

                return Message.GetMessage(MessageEnum.success);
            }
        }
        public string DeleteMeasurement(string id)
        {
            lock(MeasurementsDatabase.measurementsLock)
            {
                for(int i = 0; i < MeasurementsDatabase.Measurements.Count; i++)
                {
                    if(MeasurementsDatabase.Measurements[i].Id == id)
                    {
                        MeasurementsDatabase.Measurements.RemoveAt(i);

                        MeasurementsDatabaseWriter.WriteMeasurements(measurementsJsonFilename, MeasurementsDatabase.Measurements);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }

        public string DeleteOldMeasurements(DateTime dateTime)
        {
            bool measurementExist = false;

            lock (MeasurementsDatabase.measurementsLock)
            {
                for (int i = 0; i < MeasurementsDatabase.Measurements.Count; i++)
                {
                    if (MeasurementsDatabase.Measurements[i].DateTime <= dateTime)
                    {
                        measurementExist = true;
                        MeasurementsDatabase.Measurements.RemoveAt(i);
                        i--;
                    }
                }
                MeasurementsDatabaseWriter.WriteMeasurements(measurementsJsonFilename, MeasurementsDatabase.Measurements);

                if(measurementExist == true)
                {
                    return Message.GetMessage(MessageEnum.success);
                }
                else
                {
                    return Message.GetMessage(MessageEnum.notExist);
                }
            }
        }
        public Measurement[] GetMeasurements()
        {
            lock (MeasurementsDatabase.measurementsLock)
            {
                return MeasurementsDatabase.Measurements.ToArray();
            }
        }
        public Measurement[] GetOldMeasurements(DateTime dateTime)
        {
            List<Measurement> measurements = new();

            lock (MeasurementsDatabase.measurementsLock)
            {
                measurements = MeasurementsDatabase.Measurements.Where((m) => m.DateTime <= dateTime).ToList();
            }
            return measurements.ToArray();
        }
        public Measurement[] GetDumpsterMeasurements(string id)
        {
            List<Measurement> measurements = new();

            lock (MeasurementsDatabase.measurementsLock)
            {
                measurements = MeasurementsDatabase.Measurements.Where((m) => m.DumpsterId == id).ToList();
            }
            return measurements.ToArray();
        }
        public string GetNewId()
        {
            if (MeasurementsDatabase.Measurements.Count == 0)
            {
                return "0";
            }
            else return (int.Parse(MeasurementsDatabase.Measurements.Last().Id) + 1).ToString();
        }
        public string EmptyMeasurements(List<string> ids, DateTime dateTime) 
        {
            lock (MeasurementsDatabase.measurementsLock)
            {
                for(int i = 0; i < ids.Count; i++)
                {
                    Measurement measurement = new Measurement(GetNewId(), ids[i], dateTime, 0);
                    MeasurementsDatabase.Measurements.Add(measurement);
                }

                MeasurementsDatabaseWriter.WriteMeasurements(measurementsJsonFilename, MeasurementsDatabase.Measurements);

                return Message.GetMessage(MessageEnum.success);
            }
        }
    }
}
