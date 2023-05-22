using BingMapsRESTToolkit;
using System.Collections.Generic;

namespace PDI.ProcessingServiceRoutes.Model
{
    public class BingMapsAPI : IBingMapsAPI
    {
        private readonly string apiKey = "<API_KEY>";
        public BingMapsAPI() 
        {
        }

        public double[,] GetDistanceMatrix(List<DumpsterData> dumpsters)
        {
            List<SimpleWaypoint> waypoints = new(); //lokalizacje śmietników

            foreach (DumpsterData dumpster in dumpsters)
            {
                waypoints.Add(new SimpleWaypoint(dumpster.Location.X, dumpster.Location.Y));
            }

            DistanceMatrixRequest request = new(); //żądanie REST API

            request.Origins = waypoints;
            request.Destinations = waypoints;
            request.BingMapsKey = this.apiKey;

            Response response = request.Execute().Result; //odpowiedź REST API

            DistanceMatrix matrix = response.ResourceSets[0].Resources[0] as DistanceMatrix; //macierz odległości

            double[,] result = new double[dumpsters.Count, dumpsters.Count]; //macierz odległości do algorytmu

            foreach (DistanceMatrixCell cell in matrix.Results)
            {
                result[cell.OriginIndex, cell.DestinationIndex] = cell.TravelDistance;
            }

            return result;
        }
    }
}
