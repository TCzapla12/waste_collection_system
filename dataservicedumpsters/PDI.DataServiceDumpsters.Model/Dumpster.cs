namespace PDI.DataServiceDumpsters.Model
{
    using System.Text.Json.Serialization;
    public class Dumpster : Object
    {
        public State State { get; private set; } = State.enabled;
        public int Capacity { get; private set; } = 120;
        public int Usage { get; private set; } = 0;
        public Location Location { get; private set; }

        [JsonConstructor]
        public Dumpster(string id, State state, int capacity, int usage, Location location) : base(id)
        {
            State = state;
            Capacity = capacity;
            Usage = usage;
            Location = location;
        }
        public Dumpster(string id, Location location) : base(id)
        {
            Location = location;
        }
        public void SetUsage(int usage)
        {
            Usage = usage;
        }
        public void SetState(State state)
        {
            if(state == State.assigned && State == State.fault)
            {
                State = State.faultAssigned;
            }
            else if (state == State.enabled && State == State.faultAssigned)
            {
                State = State.fault;
            }
            else
            {
                State = state;
            }
            
        }
    }
}
