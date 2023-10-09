namespace PDI.DataServiceVehicles.Rest
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using PDI.DataServiceVehicles.Model;
    using PDI.DataServiceVehicles.Logic;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

#if DEBUG
            //services.AddScoped<IVehiclesDatabase, FakeVehiclesDatabase>();
            services.AddScoped<IVehiclesDatabase, VehiclesDatabase>();
#else
            services.AddScoped<IVehiclesDatabase, VehiclesDatabase>();
#endif
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "PDI.DataServiceVehicles", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PDI.DataServiceVehicles v1"));
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
