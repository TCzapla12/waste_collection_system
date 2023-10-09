namespace PDI.AppServiceDispatcher.Rest.Model
{
    using PDI.AppServiceDispatcher.Model;
    using System;

    public static class DataConverter
    {
        public static VehicleData ConvertToVehicleData(this Vehicle vehicle)
        {
            return new VehicleData()
            {
                Id = vehicle.Id,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Plate = vehicle.Plate,
                State = vehicle.State.ToString(),
                Capacity = vehicle.Capacity,
                Consumption = vehicle.Consumption,
                Fuel = vehicle.Fuel.ToString()
            };
        }

        public static Vehicle ConvertToVehicle(this VehicleData vehicleData)
        {
            return new Vehicle(
                vehicleData.Id,
                vehicleData.Brand,
                vehicleData.Model,
                vehicleData.Plate,
                (VehicleState)Enum.Parse(typeof(VehicleState), vehicleData.State),
                vehicleData.Capacity,
                vehicleData.Consumption,
                (Fuel)Enum.Parse(typeof(Fuel), vehicleData.Fuel));
        }
    }
}
