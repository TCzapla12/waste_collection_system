namespace PDI.SimulationModule.Simulator
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using PDI.SimulationModule.Logic;
    using System.Threading.Tasks;
    using System;
    using System.Diagnostics;
    using PDI.SimulationModule.Model;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();     

            Simulator a= new Simulator();
            Task.Run(() => a.RunSimulation());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
