using Abp.Authorization.Users;
using NoTrace.Core.MultiTenancy;

namespace NoTrace.Core.Users
{
    public class User:AbpUser<Tenant,User>
    {
         
    }
}