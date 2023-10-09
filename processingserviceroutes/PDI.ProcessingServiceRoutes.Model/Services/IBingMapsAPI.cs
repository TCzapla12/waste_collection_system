using System.Collections.Generic;

namespace PDI.ProcessingServiceRoutes.Model
{
    public interface IBingMapsAPI
    {
        public double[,] GetDistanceMatrix(List<DumpsterData> dumpsters);
    }
}
