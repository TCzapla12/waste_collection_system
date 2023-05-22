namespace PDI.AppServiceDispatcher.Model
{
    public interface IVehiclesClient
    {
        public string AddVehicle(VehicleData vehicle);
        public string EditVehicle(VehicleData vehicle);
        public string ChangeVehicleState(string id, string state);
        public string DeleteVehicle(string id);
        public VehicleData[] GetVehicles();
    }
}
