namespace PDI.DataServiceDumpsters.Rest.Model
{
    using PDI.DataServiceDumpsters.Model;
    using System;

    public static class DataConverter
    {
        public static DumpsterData ConvertToDumpsterData(this Dumpster dumpster)
        {
            return new DumpsterData()
            {
                Id = dumpster.Id,
                State = dumpster.State.ToString(),
                Capacity = dumpster.Capacity,
                Usage = dumpster.Usage,
                Location = dumpster.Location.ConvertToLocationData(),
            };
        }

        public static Dumpster ConvertToDumpster(this DumpsterData dumpsterData)
        {
            return new Dumpster(
                dumpsterData.Id,
                (State)Enum.Parse(typeof(State),
                dumpsterData.State),
                dumpsterData.Capacity,
                dumpsterData.Usage,
                dumpsterData.Location.ConvertToLocation());
        }
        public static LocationData ConvertToLocationData(this Location location)
        {
            return new LocationData { X = location.X, Y = location.Y };
        }

        public static Location ConvertToLocation(this LocationData locationData)
        {
            return new Location(locationData.X, locationData.Y);
        }
    }
}
