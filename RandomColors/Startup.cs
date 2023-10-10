using Dal;
using LogicaNegocios;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RandomColors
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de servicios
            services.AddTransient<InteractionService>();
            services.AddScoped<InteractionLN>();
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
