namespace PDI.ProcessingServiceRoutes.Model
{
    public interface IVehiclesClient
    {
        public string ChangeVehicleState(string id, string state);
        public VehicleData[] GetVehicles();
    }
}
