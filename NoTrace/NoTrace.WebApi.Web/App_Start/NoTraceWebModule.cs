using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using NoTrace.Application;
using NoTrace.EntityFramework;
using NoTrace.WebApi.Api;

namespace NoTrace.WebApi.Web
{
    [DependsOn(typeof(NoTraceDataModule),typeof(NoTraceApplicationModule),typeof(NoTraceWebApiModule))]
    public class NoTraceWebModule:AbpModule
    {
        public override void PreInitialize()
        {
        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}