using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace chilli.software.web.Infrastructure
{
    public partial class Startup
    {
        private static void AddMvc(IServiceCollection services)
        {
            services.AddMvc();
        }

        private static void UseMvc(IApplicationBuilder app)
        {
            app.UseMvc(r =>
            {
                r.MapRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}