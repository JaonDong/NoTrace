using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using NoTrace.Core.Authorization;
using NoTrace.Core.MultiTenancy;

namespace NoTrace.Core.Users
{
    public class UserManager:AbpUserManager<Tenant,Role,User>
    {
        public UserManager(AbpUserStore<Tenant, Role, User> userStore, AbpRoleManager<Tenant, Role, User> roleManager, IRepository<Tenant> tenantRepository, IMultiTenancyConfig multiTenancyConfig, IPermissionManager permissionManager, IUnitOfWorkManager unitOfWorkManager, ISettingManager settingManager, IUserManagementConfig userManagementConfig, IIocResolver iocResolver, ICacheManager cacheManager) : base(userStore, roleManager, tenantRepository, multiTenancyConfig, permissionManager, unitOfWorkManager, settingManager, userManagementConfig, iocResolver, cacheManager)
        {
        }
    }
}