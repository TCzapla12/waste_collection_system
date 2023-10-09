namespace PDI.DataServiceVehicles.Logic
{
    using PDI.DataServiceVehicles.Model;

    public class FakeVehiclesDatabase : IVehiclesDatabase
    {
        private static readonly Vehicle[] vehicles = new Vehicle[]
        {
            new Vehicle("vehicle1", "Mercedes", "Axor", "WWL", State.assigned, 20000, 20000, 30, Fuel.H2),
            new Vehicle("vehicle2", "Mercedes", "Axor", "WWl", State.working, 22000, 26000, 40, Fuel.ON)
        };
        public FakeVehiclesDatabase()
        {
        }

        public string AddVehicle(Vehicle vehicle)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string EditVehicle(Vehicle vehicle)
        {
            return Message.GetMessage(MessageEnum.success);
        }

        public string ChangeVehicleState(string id, State state)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public string DeleteVehicle(string id)
        {
            return Message.GetMessage(MessageEnum.success);
        }
        public Vehicle[] GetVehicles()
        {
            return FakeVehiclesDatabase.vehicles;
        }
        public string GetNewId()
        {
            return "1";
        }
    }
}
