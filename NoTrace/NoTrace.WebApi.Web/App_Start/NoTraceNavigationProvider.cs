using Abp.Application.Navigation;
using Abp.Localization;
using NoTrace.Core;

namespace NoTrace.WebApi.Web
{
    public class NoTraceNavigationProvider: NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Questions",
                        new LocalizableString("Questions", NoTraceConsts.LocalizationSourceName),
                        url: "#/questions",
                        icon: "fa fa-question"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Users",
                        new LocalizableString("Users", NoTraceConsts.LocalizationSourceName),
                        url: "#/users",
                        icon: "fa fa-users"
                        )
                ).AddItem(
                    new MenuItemDefinition("roles", new LocalizableString("roles", NoTraceConsts.LocalizationSourceName), url: "#/roles", icon: "fa fa-question")
                );
        }
    }
}