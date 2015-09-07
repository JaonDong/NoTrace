using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using NoTrace.Core;

namespace NoTrace.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule),typeof(NoTraceCoreModule))]
    public class NoTraceDataModule: AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}