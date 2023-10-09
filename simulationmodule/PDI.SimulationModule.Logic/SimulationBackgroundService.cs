using Microsoft.Extensions.Hosting;
using PDI.SimulationModule.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PDI.SimulationModule.Logic
{
    public class SimulationBackgroundService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("[Uruchomiono symulator]");
            ISimulator simulator = new Simulator();

            Task.Run(() => simulator.RunSimulation());

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000);
            }
        }
    }
}
