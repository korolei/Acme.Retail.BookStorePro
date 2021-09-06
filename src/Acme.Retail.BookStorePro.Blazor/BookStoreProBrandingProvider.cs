using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.Retail.BookStorePro.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class BookStoreProBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BookStorePro";
    }
}
