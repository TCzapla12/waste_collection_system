using PDI.AppServiceDispatcher.Model;
using System;
using System.Collections.Generic;

namespace PDI.AppServiceDispatcher.Logic
{
    public class Dispatcher : IDispatcher
    {
        static Dispatcher()
        {
        }
        public Dispatcher()
        {
        }
        #region Simulator
        private static readonly ISimulatorClient simulatorClient = ClientFactory.GetSimulatorClient();
        private void startSimulation()
        {
            try
            {
                simulatorClient.ChangeSimulationState(SimulationStateData.start.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void stopSimulation()
        {
            try
            {
                simulatorClient.ChangeSimulationState(SimulationStateData.stop.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void emptySimulation(List<string> ids)
        {
            EmptyDumpstersData emptyDumpsters = new EmptyDumpstersData()
            {
                Ids = ids
            };
            try
            {
                simulatorClient.EmptyDumpsters(emptyDumpsters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Dumpsters
        private static readonly object dumpstersLock = new();
        private static readonly IDumpstersClient dumpstersClient = ClientFactory.GetDumpstersClient();
        public string AddDumpster(DumpsterData dumpster)
        {
            try
            {
#if SIMULATION
                stopSimulation();
                string response = dumpstersClient.AddDumpster(dumpster);
                startSimulation();
                return response;
#else
                return dumpstersClient.AddDumpster(dumpster);
#endif
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string EditDumpster(DumpsterData dumpster)
        {
            try
            {
#if SIMULATION
                stopSimulation();
                string response = dumpstersClient.EditDumpster(dumpster);
                startSimulation();
                return response;
#else
                return dumpstersClient.EditDumpster(dumpster);
#endif
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string DeleteDumpster(string id)
        {
            try
            {
#if SIMULATION
                stopSimulation();
                string response = dumpstersClient.DeleteDumpster(id);
                startSimulation();
                return response;
#else
                return dumpstersClient.DeleteDumpster(id);
#endif
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public DumpsterData[] GetDumpsters()
        {
            try
            {
                return dumpstersClient.GetDumpsters();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region Measurements
        private static readonly object measurementsLock = new();
        private static readonly IMeasurementsClient measurementsClient = ClientFactory.GetMeasurementsClient();
        public string DeleteMeasurement(string id)
        {
            try
            {
                return measurementsClient.DeleteMeasurement(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string DeleteOldMeasurements(DateTime dateTime)
        {
            try
            {
                return measurementsClient.DeleteOldMeasurements(dateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public MeasurementData[] GetMeasurements()
        {
            try
            {
                return measurementsClient.GetMeasurements();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public MeasurementData[] GetOldMeasurements(DateTime dateTime)
        {
            try
            {
                return measurementsClient.GetOldMeasurements(dateTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public MeasurementData[] GetDumpsterMeasurements(string id)
        {
            try
            {
                return measurementsClient.GetDumpsterMeasurements(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion

        #region Vehicles
        private static readonly object vehiclesLock = new();
        private static readonly IVehiclesClient vehiclesClient = ClientFactory.GetVehiclesClient();
        public string AddVehicle(VehicleData vehicle)
        {
            try
            {
                return vehiclesClient.AddVehicle(vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string EditVehicle(VehicleData vehicle)
        {
            try
            {
                return vehiclesClient.EditVehicle(vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string DeleteVehicle(string id)
        {
            try
            {
                return vehiclesClient.DeleteVehicle(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public VehicleData[] GetVehicles()
        {
            try
            {
                return vehiclesClient.GetVehicles();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }




        #endregion

        #region Routes
        private static readonly object routesLock = new();
        private static readonly IRoutesClient routesClient = ClientFactory.GetRoutesClient();
        public string DeleteRoute(RouteData routeData)
        {
            try
            {
                string routesResponse = routesClient.DeleteRoute(routeData.Id);

                if (routesResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.routesError) + routesResponse;
                }

                string dumpstersResponse = dumpstersClient.ChangeDumpstersState(routeData.DumpstersIds, DumpsterState.enabled.ToString());

                if (dumpstersResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                }

                string vehiclesResponse = vehiclesClient.ChangeVehicleState(routeData.VehicleId, VehicleState.enabled.ToString());

                if (vehiclesResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.vehiclesError) + vehiclesResponse;
                }

                //wyzwolić calculation

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public RouteData[] GetRoutes()
        {
            try
            {
                return routesClient.GetRoutes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public RouteData[] GetOldRoutes()
        {
            try
            {
                return routesClient.GetOldRoutes();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public string StartRoute(RouteData routeData)
        {
            try
            {
                string routesResponse = routesClient.ChangeRouteState(routeData.Id, RouteState.started.ToString());

                if (routesResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.routesError) + routesResponse;
                }

                string vehiclesResponse = vehiclesClient.ChangeVehicleState(routeData.VehicleId, VehicleState.working.ToString());

                if (vehiclesResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.vehiclesError) + vehiclesResponse;
                }

                //wyzwolić calculation

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
        public string FinishRoute(RouteData routeData)
        {
            try
            {
                string routesResponse = routesClient.ChangeRouteState(routeData.Id, RouteState.finished.ToString());

                if (routesResponse != Message.GetMessage(MessageEnum.success))
                {                  
                    return Message.GetMessage(MessageEnum.routesError) + routesResponse;
                }
#if SIMULATION
                emptySimulation(routeData.DumpstersIds);
#endif
                string dumpstersResponse = dumpstersClient.ChangeDumpstersState(routeData.DumpstersIds, DumpsterState.enabled.ToString());

                if (dumpstersResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                }

                string vehiclesResponse = vehiclesClient.ChangeVehicleState(routeData.VehicleId, VehicleState.enabled.ToString());

                if (vehiclesResponse != Message.GetMessage(MessageEnum.success))
                {
                    return Message.GetMessage(MessageEnum.vehiclesError) + vehiclesResponse;
                }
                //wyzwolić calculation

                return Message.GetMessage(MessageEnum.success);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
#endregion

#region Processing
        private static readonly object processingLock = new();
        private static readonly IProcessingClient processingClient = ClientFactory.GetProcessingClient();
        public string CalculateRoute()
        {
            try
            {
                return processingClient.CalculateRoute();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error) + e.Message;
            }
        }
#endregion
    }
}
