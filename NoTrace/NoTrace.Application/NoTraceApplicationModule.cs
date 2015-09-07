using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using NoTrace.Application.Authorization;
using NoTrace.Application.Configuration;
using NoTrace.Core;

namespace NoTrace.Application
{
    [DependsOn(typeof(NoTraceCoreModule),typeof(AbpAutoMapperModule))]
    public class NoTraceApplicationModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Authorization.Providers.Add<NoTraceAuthorizationProvider>();
            Configuration.Settings.Providers.Add<MySettingProvider>();
        }
    }
}