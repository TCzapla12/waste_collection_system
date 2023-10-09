namespace PDI.DataServiceRoutes.Model
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    public class Route : Object
    {
        public string VehicleId { get; private set; } = string.Empty;
        public List<string> DumpstersIds { get; private set; }
        public State State { get; private set; } = State.notStarted;
        public double Distance { get; private set; } = 0;
        public DateTime CreateDate { get; private set; } = DateTime.Now;
        public DateTime StartDate { get; private set; } = DateTime.MinValue;
        public DateTime FinishDate { get; private set; } = DateTime.MinValue;

        [JsonConstructor]
        public Route(string id, string vehicleId, List<string> dumpstersIds, State state, double distance, DateTime createDate, DateTime startDate, DateTime finishDate) : base(id)
        {
            VehicleId = vehicleId;
            DumpstersIds = dumpstersIds;
            State = state;
            Distance = distance;
            CreateDate = createDate;
            StartDate = startDate;
            FinishDate = finishDate;
        }
        public Route(string id, List<string> dumpstersIds) : base(id)
        {
            DumpstersIds = dumpstersIds;
        }
        public void SetState(State state)
        {
            if(state == State.started)
            {
                StartDate = DateTime.Now;
            }
            else if(state == State.finished)
            {
                FinishDate = DateTime.Now;
            }
            State = state;
        }
    }
}
