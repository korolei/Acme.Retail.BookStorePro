using Localization.Resources.AbpUi;
using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.Account;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Saas.Host;
using Volo.Abp.LeptonTheme;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.CmsKit;
using Volo.Forms;
using Volo.FileManagement;
using Volo.Chat;
using Volo.Payment;
using Volo.Payment.Admin;
using Volo.Payment.Stripe;
using Volo.Docs;

namespace Acme.Retail.BookStorePro
{
    [DependsOn(
        typeof(BookStoreProApplicationContractsModule),
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpPermissionManagementHttpApiModule),
        typeof(AbpFeatureManagementHttpApiModule),
        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpAuditLoggingHttpApiModule),
        typeof(AbpIdentityServerHttpApiModule),
        typeof(AbpAccountAdminHttpApiModule),
        typeof(AbpAccountPublicHttpApiModule),
        typeof(LanguageManagementHttpApiModule),
        typeof(SaasHostHttpApiModule),
        typeof(LeptonThemeManagementHttpApiModule),
        typeof(CmsKitProHttpApiModule),
        typeof(TextTemplateManagementHttpApiModule)
        )]
    [DependsOn(typeof(FormsHttpApiModule))]
    [DependsOn(typeof(FileManagementHttpApiModule))]
    [DependsOn(typeof(ChatHttpApiModule))]
    [DependsOn(typeof(AbpPaymentHttpApiModule))]
    [DependsOn(typeof(AbpPaymentAdminHttpApiModule))]
    [DependsOn(typeof(AbpPaymentStripeHttpApiModule))]
    [DependsOn(typeof(DocsHttpApiModule))]
    public class BookStoreProHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BookStoreProResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
