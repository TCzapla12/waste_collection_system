namespace PDI.DataServiceVehicles.Rest.Model
{
    using PDI.DataServiceVehicles.Model;
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
                Load = vehicle.Load,
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
                (State)Enum.Parse(typeof(State), vehicleData.State),
                vehicleData.Capacity,
                vehicleData.Load,
                vehicleData.Consumption,
                (Fuel)Enum.Parse(typeof(Fuel), vehicleData.Fuel));
        }
    }
}
