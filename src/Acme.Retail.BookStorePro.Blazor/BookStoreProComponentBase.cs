using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Acme.Retail.BookStorePro.Blazor
{
    public abstract class BookStoreProComponentBase : AbpComponentBase
    {
        protected BookStoreProComponentBase()
        {
            LocalizationResource = typeof(BookStoreProResource);
        }
    }
}
