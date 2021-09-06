using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.Application.Services;

namespace Acme.Retail.BookStorePro
{
    /* Inherit your application services from this class.
     */
    public abstract class BookStoreProAppService : ApplicationService
    {
        protected BookStoreProAppService()
        {
            LocalizationResource = typeof(BookStoreProResource);
        }
    }
}
