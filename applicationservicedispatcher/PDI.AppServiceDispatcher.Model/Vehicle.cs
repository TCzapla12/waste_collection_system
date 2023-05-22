namespace PDI.AppServiceDispatcher.Model
{
    using System.Text.Json.Serialization;
    public class Vehicle : Object
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Plate { get; private set; }
        public VehicleState State { get; private set; } = VehicleState.enabled;
        public int Capacity { get; private set; } = 15000;
        public int Consumption { get; private set; } = 40;
        public Fuel Fuel { get; private set; } = Fuel.ON;

        [JsonConstructor]
        public Vehicle(string id, string brand, string model, string plate, VehicleState state, int capacity, int consumption, Fuel fuel) : base(id)
        {
            Brand = brand;
            Model = model;
            Plate = plate;
            State = state;
            Capacity = capacity;
            Consumption = consumption;
            Fuel = fuel;
        }
        public Vehicle(string id, string brand, string model, string plate) : base(id)
        {
            Brand = brand;
            Model = model;
            Plate = plate;
            
        }
    }
}
