using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.Retail.BookStorePro.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BookStoreProController : AbpController
    {
        protected BookStoreProController()
        {
            LocalizationResource = typeof(BookStoreProResource);
        }
    }
}