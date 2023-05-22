using PDI.SimulationModule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PDI.SimulationModule.Logic
{
    public class Simulator : ISimulator
    {
        private static readonly ISensorClient sensorClient = ClientFactory.GetSensorClient();
        private static IList<DumpsterData> Dumpsters = new List<DumpsterData>();
        private static List<Node> Nodes = new List<Node>();
        private static SimulationState State = SimulationState.start;
        private static int SimulationTime = 0;
        static Simulator()
        {
            ConfigSimulation();
        }
        public Simulator()
        {
        }

        private static void ConfigSimulation()
        {
            DumpsterData[] dumpsters = GetDumpsters();
            if(dumpsters != null)
            {
                Simulator.Dumpsters = dumpsters;
            } 
            foreach (DumpsterData dumpster in Simulator.Dumpsters)
            {
                if (dumpster.State != DumpsterState.disabled.ToString())
                {
                    Simulator.Nodes.Add(new Node(dumpster.Id, dumpster.Capacity, dumpster.Usage, SimulationTime));
                }
            }
        }

        public void RunSimulation()
        {
            while (true)
            {
                if (State == SimulationState.start)
                {
                    int idNode = -1;
                    double minTime = double.MaxValue;

                    for (int i = 0; i < Simulator.Nodes.Count; i++)
                    {
                        if (minTime > Simulator.Nodes[i].GetTime() && Simulator.Nodes[i].Usage < 100)
                        {
                            idNode = i;
                            minTime = Simulator.Nodes[i].GetTime();
                        }
                    }
                    if (idNode != -1)
                    {
                        int sleepTime = (int)minTime - SimulationTime;
                        SimulationTime = (int)minTime;
                        Thread.Sleep(sleepTime * 1000);
                        int tmpTime = (int)Math.Round(minTime * 1440, 0);
                        Simulator.Nodes[idNode].CalculateUsage();
                        DateTime tmpDate = DateTime.Now.AddSeconds(tmpTime);
                        MeasurementData measurement = new MeasurementData()
                        {
                            Id = "0",
                            DumpsterId = Nodes[idNode].Id,
                            Usage = Nodes[idNode].Usage,
                            DateTime = tmpDate.ToString("s")
                        };
                        Console.WriteLine(AddData(measurement));
                    }
                    else
                    {
                        Console.WriteLine("[Zakończono symulację]");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("[Symulacja zatrzymana]");
                }
            }
        }


        public string AddData(MeasurementData measurement)
        {
            //if(measurement.Usage > 100 || measurement.Usage < 0)
            //{
            //    return Message.GetMessage(MessageEnum.rangeError);
            //}

            try
            {
                return sensorClient.AddData(measurement);
                //string dumpstersResponse = dumpstersClient.ChangeDumpsterUsage(measurement.DumpsterId, measurement.Usage);

                //if(dumpstersResponse != Message.GetMessage(MessageEnum.success))
                //{
                //    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                //}

                //string measurementsResponse = measurementsClient.AddMeasurement(measurement);

                //if (measurementsResponse != Message.GetMessage(MessageEnum.success))
                //{
                //    return Message.GetMessage(MessageEnum.measurementsError) + measurementsResponse;
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Message.GetMessage(MessageEnum.error);
            }
        }

        public string EmptyMeasurements(EmptyMeasurementsData emptyMeasurements)
        {
            throw new NotImplementedException();
        }
        public static DumpsterData[] GetDumpsters()
        {
            try
            {
                return sensorClient.GetDumpsters();
                //string dumpstersResponse = dumpstersClient.ChangeDumpsterUsage(measurement.DumpsterId, measurement.Usage);

                //if(dumpstersResponse != Message.GetMessage(MessageEnum.success))
                //{
                //    return Message.GetMessage(MessageEnum.dumpstersError) + dumpstersResponse;
                //}

                //string measurementsResponse = measurementsClient.AddMeasurement(measurement);

                //if (measurementsResponse != Message.GetMessage(MessageEnum.success))
                //{
                //    return Message.GetMessage(MessageEnum.measurementsError) + measurementsResponse;
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string ChangeSimulationState(SimulationState state)
        {
            if (state == SimulationState.stop)
            {
                State = state;
            }
            else if (state == SimulationState.start)
            {
                Nodes = new List<Node>();
                ConfigSimulation();
                State = state;
            }
            return Message.GetMessage(MessageEnum.success);
        }

        public string EmptyDumpsters(EmptyDumpstersData emptyDumpsters)
        {
            State = SimulationState.stop;
            EmptyMeasurementsData emptyMeasurements = new EmptyMeasurementsData()
            {
                Ids = emptyDumpsters.Ids,
                DateTime = DateTime.Now.AddSeconds(SimulationTime * 1440).ToString("s")
            };
            sensorClient.EmptyMeasurements(emptyMeasurements);
            Nodes = new List<Node>();
            ConfigSimulation();
            State = SimulationState.start;

            return Message.GetMessage(MessageEnum.success);
        }
    }
}
