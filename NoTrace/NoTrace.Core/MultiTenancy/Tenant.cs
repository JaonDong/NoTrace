using Abp.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.Core.MultiTenancy
{
    public class Tenant:AbpTenant<Tenant,User>
    {
        protected Tenant()
        {
        }

        public Tenant(string tenancyName, string name)
           : base(tenancyName, name)
        {
        }
    }

}