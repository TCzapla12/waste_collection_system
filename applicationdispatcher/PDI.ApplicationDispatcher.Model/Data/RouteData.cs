using System.Collections.Generic;

namespace PDI.ApplicationDispatcher.Model
{
    public class RouteData
    {
        public string Id { get; set; }
        public string VehicleId { get; set; }
        public List<string> DumpstersIds { get; set; }
        public RouteState State { get; set; }
        public double Distance { get; set; }
        public string CreateDate { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
    }
}

