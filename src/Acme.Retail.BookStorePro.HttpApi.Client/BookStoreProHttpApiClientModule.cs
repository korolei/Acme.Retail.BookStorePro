using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.SettingManagement;
using Volo.Saas.Host;
using Volo.CmsKit;
using Volo.Forms;
using Volo.FileManagement;
using Volo.Chat;
using Volo.Payment;
using Volo.Payment.Admin;
using Volo.Docs;

namespace Acme.Retail.BookStorePro
{
    [DependsOn(
        typeof(BookStoreProApplicationContractsModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule),
        typeof(AbpSettingManagementHttpApiClientModule),
        typeof(SaasHostHttpApiClientModule),
        typeof(AbpAuditLoggingHttpApiClientModule),
        typeof(AbpIdentityServerHttpApiClientModule),
        typeof(AbpAccountAdminHttpApiClientModule),
        typeof(AbpAccountPublicHttpApiClientModule),
        typeof(LanguageManagementHttpApiClientModule),
        typeof(LeptonThemeManagementHttpApiClientModule),
        typeof(CmsKitProHttpApiClientModule),
        typeof(TextTemplateManagementHttpApiClientModule)
    )]
    [DependsOn(typeof(FormsHttpApiClientModule))]
    [DependsOn(typeof(FileManagementHttpApiClientModule))]
    [DependsOn(typeof(ChatHttpApiClientModule))]
    [DependsOn(typeof(AbpPaymentHttpApiClientModule))]
    [DependsOn(typeof(AbpPaymentAdminHttpApiClientModule))]
    [DependsOn(typeof(DocsHttpApiClientModule))]
    public class BookStoreProHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BookStoreProApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
