using Volo.Abp.Settings;

namespace TVersion.Settings
{
    public class TVersionSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TVersionSettings.MySetting1));
        }
    }
}
