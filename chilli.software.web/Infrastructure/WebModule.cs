using Abp.AspNetCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace chilli.software.web.Infrastructure
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class WebModule : AbpModule
    {
        public override void PreInitialize()
        {
            Localization.Configuration.Localization.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(WebModule).GetAssembly());
        }
    }
}