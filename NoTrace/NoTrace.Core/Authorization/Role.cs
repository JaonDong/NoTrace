using Abp.Authorization.Roles;
using NoTrace.Core.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.Core.Authorization
{
    public class Role:AbpRole<Tenant,User>
    {
         
    }
}