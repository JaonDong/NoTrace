using System.Reflection;
using Abp.Modules;
using Abp.Zero;

namespace NoTrace.Core
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class NoTraceCoreModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}