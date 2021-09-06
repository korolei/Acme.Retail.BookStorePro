using Volo.Abp.Settings;

namespace Acme.Retail.BookStorePro.Settings
{
    public class BookStoreProSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BookStoreProSettings.MySetting1));
        }
    }
}
