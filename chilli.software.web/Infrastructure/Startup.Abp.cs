using System;
using System.Reflection;
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
                a.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseAbpLog4Net().WithConfig("log4net.config"));
                a.IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
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