using System.Data.Common;
using Abp.Zero.EntityFramework;
using NoTrace.Core.Authorization;
using NoTrace.Core.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.EntityFramework.EntityFramework
{
    public class NoTraceDbContext: AbpZeroDbContext<Tenant, Role, User>
    {
        /* NOTE: 
       *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
       *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
       *   pass connection string name to base classes. ABP works either way.
       */
        public NoTraceDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ModuleZeroSampleProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ModuleZeroSampleProjectDbContext since ABP automatically handles it.
         */
        public NoTraceDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public NoTraceDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}