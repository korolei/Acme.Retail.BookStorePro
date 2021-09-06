using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Acme.Retail.BookStorePro.Web.Public.Pages
{
    public class IndexModel : BookStoreProPublicPageModel
    {
        public void OnGet()
        {

        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}
