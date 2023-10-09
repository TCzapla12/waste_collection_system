namespace PDI.DataServiceMeasurements.Rest
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.OpenApi.Models;

    using PDI.DataServiceMeasurements.Model;
    using PDI.DataServiceMeasurements.Logic;

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
            //services.AddScoped<IMeasurementsDatabase, FakeMeasurementsDatabase>();
            services.AddScoped<IMeasurementsDatabase, MeasurementsDatabase>();
#else
            services.AddScoped<IMeasurementsDatabase, MeasurementsDatabase>();
#endif
            services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "PDI.DataServiceMeasurements", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PDI.DataServiceMeasurements v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
