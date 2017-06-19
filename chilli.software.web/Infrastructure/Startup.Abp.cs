using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace chilli.software.web.Infrastructure
{
    public partial class Startup
    {
        private IServiceProvider AddAbp(IServiceCollection services)
        {
            return services.AddAbp<WebModule>(a =>
            {
                //Configure Log4Net logging
                a.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        private void UseAbp(IApplicationBuilder app)
        {
            app.UseAbp(a =>
            {
                a.UseAbpRequestLocalization = false;
            });

            app.UseAbpRequestLocalization();
        }
    }
}