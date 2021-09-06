using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
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
        typeof(BookStoreProDomainSharedModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(SaasHostApplicationContractsModule),
        typeof(AbpAuditLoggingApplicationContractsModule),
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpAccountPublicApplicationContractsModule),
        typeof(AbpAccountAdminApplicationContractsModule),
        typeof(LanguageManagementApplicationContractsModule),
        typeof(LeptonThemeManagementApplicationContractsModule),
        typeof(CmsKitProApplicationContractsModule),
        typeof(TextTemplateManagementApplicationContractsModule)
    )]
    [DependsOn(typeof(FormsApplicationContractsModule))]
    [DependsOn(typeof(FileManagementApplicationContractsModule))]
    [DependsOn(typeof(ChatApplicationContractsModule))]
    [DependsOn(typeof(AbpPaymentApplicationContractsModule))]
    [DependsOn(typeof(AbpPaymentAdminApplicationContractsModule))]
    [DependsOn(typeof(DocsApplicationContractsModule))]
    public class BookStoreProApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BookStoreProDtoExtensions.Configure();
        }
    }
}
