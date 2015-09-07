using Abp.Authorization;

namespace NoTrace.Application.Authorization
{
    public class NoTraceAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}