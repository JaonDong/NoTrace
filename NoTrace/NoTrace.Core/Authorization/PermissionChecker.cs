using Abp.Authorization;
using Abp.Authorization.Users;
using NoTrace.Core.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.Core.Authorization
{
    public class PermissionChecker:PermissionChecker<Tenant,Role,User>
    {
        public PermissionChecker(AbpUserManager<Tenant, Role, User> userManager) : base(userManager)
        {
        }
    }
}