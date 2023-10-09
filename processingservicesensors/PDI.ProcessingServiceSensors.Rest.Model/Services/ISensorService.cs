using PDI.ProcessingServiceSensors.Model;

namespace PDI.ProcessingServiceSensors.Rest.Model
{
  public interface ISensorService
  {
        public string AddData(MeasurementData measurement);
        public DumpsterData[] GetDumpsters();
        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements);
    }
}
