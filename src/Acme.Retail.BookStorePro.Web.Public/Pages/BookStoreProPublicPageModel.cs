using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.Retail.BookStorePro.Web.Public.Pages
{
    /* Inherit your Page Model classes from this class.
     */
    public abstract class BookStoreProPublicPageModel : AbpPageModel
    {
        protected BookStoreProPublicPageModel()
        {
            LocalizationResourceType = typeof(BookStoreProResource);
        }
    }
}
