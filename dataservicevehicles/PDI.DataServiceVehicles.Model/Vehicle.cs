namespace PDI.DataServiceVehicles.Model
{
    using System.Text.Json.Serialization;
    public class Vehicle : Object
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }
        public State State { get; private set; } = State.enabled;
        public int Capacity { get; private set; } = 15000;
        public int Load { get; private set; } = 20000;
        public int Consumption { get; private set; } = 40;
        public Fuel Fuel { get; private set; } = Fuel.ON;

        [JsonConstructor]
        public Vehicle(string id, string brand, string model, string plate, State state, int capacity, int load, int consumption, Fuel fuel) : base(id)
        {
            Brand = brand;
            Model = model;
            Plate = plate;
            State = state;
            Capacity = capacity;
            Load = load;
            Consumption = consumption;
            Fuel = fuel;
        }
        public Vehicle(string id, string brand, string model, string plate) : base(id)
        {
            Brand = brand;
            Model = model;
            Plate = plate;
            
        }
        public void SetState(State state)
        {
            State = state;
        }
    }
}
