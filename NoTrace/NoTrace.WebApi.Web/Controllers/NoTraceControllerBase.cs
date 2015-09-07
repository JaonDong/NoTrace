using Abp.Web.Mvc.Controllers;
using NoTrace.Core;

namespace NoTrace.WebApi.Web.Controllers
{
    public class NoTraceControllerBase:AbpController
    {
        public NoTraceControllerBase()
        {
            LocalizationSourceName = NoTraceConsts.LocalizationSourceName;
        }
    }
}