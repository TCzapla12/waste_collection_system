using PDI.ProcessingServiceRoutes.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PDI.ProcessingServiceRoutes.Logic
{
    public class Route : IRoute
    {
        private static IList<DumpsterData> Dumpsters = new List<DumpsterData>();
        private static IList<VehicleData> Vehicles = new List<VehicleData>();
        //private static IList<RouteData> Routes = new List<RouteData>();

        private static readonly IDumpstersClient dumpstersClient = ClientFactory.GetDumpstersClient();
        private static readonly IVehiclesClient vehiclesClient = ClientFactory.GetVehiclesClient();
        private static readonly IRoutesClient routesClient = ClientFactory.GetRoutesClient();
        private static readonly IBingMapsAPI bingMapsAPI = ClientFactory.GetBingMapsAPI();

        private static readonly object dumpstersLock = new();
        private static readonly object vehiclesLock = new();
        private static readonly object routesLock = new();
        private static readonly object serviceLock = new();

        private static readonly int FaultyDumpsterUsage = 50;
        private static readonly double UsageFactor = 1;
        private static readonly double DistanceFactor = 1;

        static Route()
        {
            lock (Route.serviceLock)
            {
                Route.GetData();
            }
        }
        public Route()
        {
        }



        public string CalculateRoute()
        {
            string response = GetData();
            if (response != Message.GetMessage(MessageEnum.success))
            {
                return response;
            }

            try
            {
                VehicleData currentVehicle = Route.Vehicles.Where(v => v.State == VehicleState.enabled.ToString()).OrderByDescending(v => v.Capacity).First(); //wybrana śmieciarka

                List<DumpsterData> currentDumpsters = Route.Dumpsters.Where(d => d.State == DumpsterState.enabled.ToString() || d.State == DumpsterState.fault.ToString()).ToList(); //rozważane śmietniki

                double[,] distanceMatrix = bingMapsAPI.GetDistanceMatrix(currentDumpsters); //macierz odległości

                int weight = currentVehicle.Capacity; //dopuszczalne zapełnienie
                bool[] used = new bool[currentDumpsters.Count]; //wybrane śmietniki
                List<int> order = new(); //kolejność śmietników

                int index = GetFirstDumpsterIndex(currentDumpsters); //aktualny indeks śmietnika

                double currentValue = 0; //aktualna wartość
                double currentWeight = GetWeight(currentDumpsters[index]); //aktualne zapełnienie
                double currentDistance = 0;
                used[index] = true;

                for (int i = 0; i < currentDumpsters.Count; i++)
                {
                    order.Add(index);
                    double maxValue = 0; //najwyższa wartość
                    int newIndex = 0; //następny śmietnik

                    for (int j = 0; j < currentDumpsters.Count; j++)
                    {
                        if (index != j && used[j] == false)
                        {
                            double value = GetValue(distanceMatrix[index, j], currentDumpsters[j].Usage);
                            if (maxValue < value && currentWeight + GetWeight(currentDumpsters[j]) < weight)
                            {
                                maxValue = value;
                                newIndex = j;
                            }
                        }
                    }

                    if (maxValue == 0)
                    {
                        break;
                    }
                    currentDistance += distanceMatrix[index, newIndex];
                    index = newIndex;
                    used[index] = true;
                    currentValue += maxValue;
                    currentWeight += GetWeight(currentDumpsters[index]);
                    
                }

                List<string> dumpstersIds = new();
                for (int i = 0; i < order.Count; i++)
                {
                    dumpstersIds.Add(currentDumpsters[order[i]].Id);
                }
                RouteData routeData = new RouteData()
                {
                    VehicleId = currentVehicle.Id,
                    DumpstersIds = dumpstersIds,
                    State = RouteState.notStarted.ToString(),
                    Distance = currentDistance,
                    CreateDate = DateTime.Now.ToString(),
                    StartDate = DateTime.MinValue.ToString(),
                    FinishDate = DateTime.MinValue.ToString(),
                };

                response = AddData(routeData);
                if (response != Message.GetMessage(MessageEnum.success))
                {
                    return response;
                }

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }

        private static string GetData()
        {
            try
            {
                Route.Dumpsters = dumpstersClient.GetDumpsters();

                Route.Vehicles = vehiclesClient.GetVehicles();

                //Route.Routes = routesClient.GetRoutes();

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }

        private static string AddData(RouteData routeData)
        {
            try
            {
                routesClient.AddRoute(routeData);

                vehiclesClient.ChangeVehicleState(routeData.VehicleId, VehicleState.assigned.ToString());

                dumpstersClient.ChangeDumpstersState(routeData.DumpstersIds, DumpsterState.assigned.ToString());

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }

        private static double GetValue(double distance, int usage)
        {
            return ((1 / distance) * Route.DistanceFactor) * (usage * Route.UsageFactor);
        }

        private static double GetWeight(DumpsterData dumpster)
        {
            if (dumpster.State == DumpsterState.fault.ToString())
            {
                return 0.01 * Route.FaultyDumpsterUsage * dumpster.Capacity;
            }
            return 0.01 * dumpster.Usage * dumpster.Capacity;
        }

        private static int GetFirstDumpsterIndex(List<DumpsterData> dumpsters)
        {
            int maxUsage = 0;
            int index = 0;
            for (int i = 0; i < dumpsters.Count; i++)
            {
                if (dumpsters[i].State == DumpsterState.fault.ToString() && maxUsage < Route.FaultyDumpsterUsage)
                {
                    index = i;
                    maxUsage = Route.FaultyDumpsterUsage;
                }
                else if (dumpsters[i].Usage > maxUsage)
                {
                    index = i;
                    maxUsage = dumpsters[i].Usage;
                }
            }
            return index;
        }
    }
}
