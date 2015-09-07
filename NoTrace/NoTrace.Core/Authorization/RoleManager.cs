using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using NoTrace.Core.MultiTenancy;
using NoTrace.Core.Users;

namespace NoTrace.Core.Authorization
{
    public class RoleManager:AbpRoleManager<Tenant,Role,User>
    {
        public RoleManager(AbpRoleStore<Tenant, Role, User> store, IPermissionManager permissionManager, IRoleManagementConfig roleManagementConfig, ICacheManager cacheManager) : base(store, permissionManager, roleManagementConfig, cacheManager)
        {
        }
    }
}