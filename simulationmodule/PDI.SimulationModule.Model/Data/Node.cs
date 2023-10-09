using System;
using System.Threading;
using System.Threading.Tasks;

namespace PDI.SimulationModule.Model
{
    public class Node : Object
    {
        public int Capacity { get; private set; }
        public int Usage { get; private set; }
        public double LambdaTime { get; private set; } = 0.015;
        public double LambdaUsage { get; private set; } = 0.15;

        public double Time { get; private set; } = 0;
        public Node(string id, int capacity, int usage, double time) : base(id)
        {
            Capacity = capacity;
            Usage = usage;
            Time = time + getRandomValue(LambdaTime);
        }
        public double GetTime()
        {
            return Time;
        }
        public void CalculateUsage()
        {
            double usage = getRandomValue(LambdaUsage);
            Usage += (int)Math.Round(usage, 0);
            if(Usage >= 100) 
            {
                Usage = 100;
                Console.WriteLine("[=====" + Id + "=====]"); 
            }
            Console.WriteLine(Id+ " " + Time + " " + Usage);
            Time += getRandomValue(LambdaTime);
        }
        private double getRandomValue(double lambda)
        {
            Random random = new Random();
            double y = random.NextDouble();
            return Math.Log(1 - y) / (-lambda);
        }

        
    }
}
