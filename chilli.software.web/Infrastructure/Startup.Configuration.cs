using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace chilli.software.web.Infrastructure
{
    public partial class Startup 
    {
        private static void AddConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<SendgridConfiguration>(configuration.GetSection("Mailgun"));
        }
    }
}