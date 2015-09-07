using System.Collections.Generic;
using Abp.Configuration;

namespace NoTrace.Application.Configuration
{
    public class MySettingProvider: SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}