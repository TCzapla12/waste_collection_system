namespace PDI.DataServiceVehicles.Model
{
    public interface IVehiclesDatabase
    {
        public string AddVehicle(Vehicle vehicle);
        public string EditVehicle(Vehicle vehicle);
        public string ChangeVehicleState(string id, State state);
        public string DeleteVehicle(string id);
        public Vehicle[] GetVehicles();
        public string GetNewId();
    }
}
