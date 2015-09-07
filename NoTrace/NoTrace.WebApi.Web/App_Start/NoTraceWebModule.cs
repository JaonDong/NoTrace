﻿using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Localization;
using Abp.Localization.Sources.Xml;
using Abp.Modules;
using NoTrace.Application;
using NoTrace.Core;
using NoTrace.EntityFramework;
using NoTrace.WebApi.Api;

namespace NoTrace.WebApi.Web
{
    [DependsOn(typeof(NoTraceDataModule),typeof(NoTraceApplicationModule),typeof(NoTraceWebApiModule))]
    public class NoTraceWebModule:AbpModule
    {
        public override void PreInitialize()
        {
            //Add/remove languages for your application
            Configuration.Localization.Languages.Add(new LanguageInfo("en", "English", "famfamfam-flag-england", true));
            Configuration.Localization.Languages.Add(new LanguageInfo("tr", "Türkçe", "famfamfam-flag-tr"));
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-CN", "中文简体", "famfamfam-flag-cn"));
            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new XmlLocalizationSource(
                    NoTraceConsts.LocalizationSourceName,
                    HttpContext.Current.Server.MapPath("~/Localization/NoTrace")
                    )
                );

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<NoTraceNavigationProvider>();

        }
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}