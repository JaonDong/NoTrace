using Abp.Web.Mvc.Views;

namespace NoTrace.WebApi.Web.Views
{
    public class NoTraceWebViewPageBase : NoTraceWebViewPage<dynamic>
    {

    }

    public class NoTraceWebViewPage<TModel>: AbpWebViewPage<TModel>
    {
        protected NoTraceWebViewPage()
        {
            LocalizationSourceName = "";
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}