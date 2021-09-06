using Volo.Abp.Modularity;

namespace Acme.Retail.BookStorePro
{
    [DependsOn(
        typeof(BookStoreProApplicationModule),
        typeof(BookStoreProDomainTestModule)
        )]
    public class BookStoreProApplicationTestModule : AbpModule
    {

    }
}