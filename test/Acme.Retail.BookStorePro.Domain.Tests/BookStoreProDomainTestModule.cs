using Acme.Retail.BookStorePro.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Acme.Retail.BookStorePro
{
    [DependsOn(
        typeof(BookStoreProEntityFrameworkCoreTestModule)
        )]
    public class BookStoreProDomainTestModule : AbpModule
    {

    }
}