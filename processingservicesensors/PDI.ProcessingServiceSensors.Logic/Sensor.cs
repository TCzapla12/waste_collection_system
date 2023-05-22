using PDI.ProcessingServiceSensors.Model;
using System;

namespace PDI.ProcessingServiceSensors.Logic
{
    public class Sensor : ISensor
    {
        static Sensor()
        {
        }
        public Sensor()
        {
        }

        private static readonly IDumpstersClient dumpstersClient = ClientFactory.GetDumpstersClient();
        private static readonly IMeasurementsClient measurementsClient = ClientFactory.GetMeasurementsClient();
        public string AddData(MeasurementData measurement)
        {
            if(measurement.Usage > 100 || measurement.Usage < 0)
            {
                return Message.GetMessage(MessageEnum.rangeError);
            }

            try
            {
                string dumpstersResponse = dumpstersClient.ChangeDumpsterUsage(measurement.DumpsterId, measurement.Usage);

                if(dumpstersResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                }

                string measurementsResponse = measurementsClient.AddMeasurement(measurement);

                if (measurementsResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.measurementsError) + measurementsResponse;
                }

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }

        public DumpsterData[] GetDumpsters()
        {
            try
            {
                return dumpstersClient.GetDumpsters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            EmptyDumpstersData emptyDumpsters = new EmptyDumpstersData() { Ids = emptyMeasurements.Ids };
            try
            {
                string dumpstersResponse = dumpstersClient.EmptyDumpsters(emptyDumpsters);

                if (dumpstersResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                }

                string measurementsResponse = measurementsClient.EmptyMeasurements(emptyMeasurements);

                if (measurementsResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.measurementsError) + measurementsResponse;
                }

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
    }
}
