using Dal;
using LogicaNegocios;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RandomColors
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de servicios
            services.AddScoped<InteractionService>();
            services.AddScoped<InteractionRepository>();
            services.AddSingleton(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                return configuration.GetConnectionString("RandomColorsStoreDatabase:ConnectionString");
            });
            var connectionString = _configuration.GetConnectionString("RandomColorsStoreDatabase:ConnectionString");

          
          

            // Otras configuraciones de inyección de dependencias
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configuración de middleware
            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
