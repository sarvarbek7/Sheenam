using Microsoft.OpenApi.Models;
using Sheenam.Core.Api.Brokers.Loggings;
using Sheenam.Core.Api.Brokers.Storages;
using Sheenam.Core.Api.Services.Foundation.Guests;

namespace Sheenam.Core.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            AddBrokers(services);
            AddServices(services);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: new OpenApiInfo
                    {
                        Title = "Sheenam.Core.Api",
                        Version = "v1"
                    }
                );
            });
        }

        public void Configure(
            IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseSwagger();
                applicationBuilder.UseSwaggerUI(options =>

                options.SwaggerEndpoint(
                    url: "/swagger/v1/swagger.json",
                    name: "Sheenam.Core.Api v1"));
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }

        private static void AddBrokers(IServiceCollection services)
        {
            services.AddTransient<IStorageBroker, StorageBroker>();
            services.AddTransient<ILoggingBroker, LoggingBroker>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IGuestService, GuestService>();
        }
    }
}