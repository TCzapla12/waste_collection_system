namespace PDI.DataServiceVehicles.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using PDI.DataServiceVehicles.Model;
    public class VehiclesDatabase : IVehiclesDatabase
    {
        private const string vehiclesJsonFilename = "vehicles.json";

        private static readonly IList<Vehicle> Vehicles = new List<Vehicle>();

        private static readonly object vehiclesLock = new ();

        static VehiclesDatabase()
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                VehiclesDatabase.Vehicles = VehiclesDatabaseReader.ReadVehicles(vehiclesJsonFilename);
            }
        }

        public VehiclesDatabase()
        {
        }
        public string AddVehicle(Vehicle vehicle)
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                VehiclesDatabase.Vehicles.Add(vehicle);

                VehiclesDatabaseWriter.WriteVehicles(vehiclesJsonFilename, VehiclesDatabase.Vehicles);

                return Message.GetMessage(MessageEnum.success);
            }
        }

        public string EditVehicle(Vehicle vehicle)
        {
            string searchId = vehicle.Id;

            lock (VehiclesDatabase.vehiclesLock)
            {
                for (int i = 0; i < VehiclesDatabase.Vehicles.Count; i++)
                {
                    if (VehiclesDatabase.Vehicles[i].Id == searchId)
                    {
                        if (VehiclesDatabase.Vehicles[i].State == State.assigned || VehiclesDatabase.Vehicles[i].State == State.working)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        VehiclesDatabase.Vehicles[i] = vehicle;

                        VehiclesDatabaseWriter.WriteVehicles(vehiclesJsonFilename, VehiclesDatabase.Vehicles);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }

        public string ChangeVehicleState(string id, State state)
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                for(int i = 0; i < VehiclesDatabase.Vehicles.Count; i++)
                {
                    if(VehiclesDatabase.Vehicles[i].Id == id)
                    {
                        if (VehiclesDatabase.Vehicles[i].State == state)
                        {
                            return Message.GetMessage(MessageEnum.sameState);
                        }
                        switch (VehiclesDatabase.Vehicles[i].State)
                        {
                            case State.enabled:
                                {
                                    if(state == State.working)
                                    {
                                        return Message.GetMessage(MessageEnum.notAvailable);
                                    }
                                    break;
                                }
                            case State.disabled:
                                {
                                    if(state == State.assigned || state == State.working)
                                    {
                                        return Message.GetMessage(MessageEnum.notAvailable);
                                    }
                                    break;
                                }
                            case State.working:
                                {
                                    if (state == State.assigned)
                                    {
                                        return Message.GetMessage(MessageEnum.notAvailable);
                                    }
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                        VehiclesDatabase.Vehicles[i].SetState(state);

                        VehiclesDatabaseWriter.WriteVehicles(vehiclesJsonFilename, VehiclesDatabase.Vehicles);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public string DeleteVehicle(string id)
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                for (int i = 0; i < VehiclesDatabase.Vehicles.Count; i++)
                {
                    if (VehiclesDatabase.Vehicles[i].Id == id)
                    {
                        if (VehiclesDatabase.Vehicles[i].State == State.assigned || VehiclesDatabase.Vehicles[i].State == State.working)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        VehiclesDatabase.Vehicles.RemoveAt(i);

                        VehiclesDatabaseWriter.WriteVehicles(vehiclesJsonFilename, VehiclesDatabase.Vehicles);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }  
            }
            return Message.GetMessage(MessageEnum.notExist);
        }

        public Vehicle[] GetVehicles()
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                return VehiclesDatabase.Vehicles.ToArray();
            }
        }

        public string GetNewId()
        {
            lock (VehiclesDatabase.vehiclesLock)
            {
                if (VehiclesDatabase.Vehicles.Count == 0)
                {
                    return "0";
                }
                else return (int.Parse(VehiclesDatabase.Vehicles.Last().Id) + 1).ToString();
            }
        }
    }
}
