using Volo.Abp.Identity;

namespace Acme.Retail.BookStorePro
{
    public static class BookStoreProConsts
    {
        public const string DbTablePrefix = "App";
        public const string DbSchema = null;
        public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
        public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
    }
}
