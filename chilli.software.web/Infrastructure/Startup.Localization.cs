using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace chilli.software.web.Infrastructure
{
    public partial class Startup
    {
        private void AddLocalization(IServiceCollection services)
        {
            //services.AddLocalization(l =>
            //{
            //    l.ResourcesPath = "Resources";
            //});
        }

        private void UseLocalization(IApplicationBuilder app)
        {
            //app.UseMvc(r =>
            //{
            //    r.MapRoute("default", "{controller=Home}/{action=Index}");
            //});
        }
    }
}