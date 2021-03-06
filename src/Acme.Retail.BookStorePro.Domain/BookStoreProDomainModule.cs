using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Acme.Retail.BookStorePro.Localization;
using Acme.Retail.BookStorePro.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.LanguageManagement;
using Volo.Abp.LeptonTheme.Management;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Saas;
using Volo.Abp.BlobStoring.Database;
using Volo.CmsKit;
using Volo.CmsKit.Contact;
using Volo.CmsKit.Newsletters;
using Volo.Forms;
using Volo.FileManagement;
using Volo.Chat;
using Volo.Payment;
using Volo.Payment.Payu;
using Volo.Payment.TwoCheckout;
using Volo.Payment.Iyzico;
using Volo.Payment.PayPal;
using Volo.Payment.Stripe;
using Volo.Docs;

namespace Acme.Retail.BookStorePro
{
    [DependsOn(
        typeof(BookStoreProDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpFeatureManagementDomainModule),
        typeof(AbpIdentityProDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule),
        typeof(AbpIdentityServerDomainModule),
        typeof(AbpPermissionManagementDomainIdentityServerModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(SaasDomainModule),
        typeof(TextTemplateManagementDomainModule),
        typeof(LeptonThemeManagementDomainModule),
        typeof(LanguageManagementDomainModule),
        typeof(AbpEmailingModule),
        typeof(CmsKitProDomainModule),
        typeof(BlobStoringDatabaseDomainModule)
        )]
    [DependsOn(typeof(FormsDomainModule))]
    [DependsOn(typeof(FileManagementDomainModule))]
    [DependsOn(typeof(ChatDomainModule))]
    [DependsOn(typeof(AbpPaymentDomainModule))]
    [DependsOn(typeof(AbpPaymentPayuDomainModule))]
    [DependsOn(typeof(AbpPaymentTwoCheckoutDomainModule))]
    [DependsOn(typeof(AbpPaymentIyzicoDomainModule))]
    [DependsOn(typeof(AbpPaymentPayPalDomainModule))]
    [DependsOn(typeof(AbpPaymentStripeDomainModule))]
    [DependsOn(typeof(DocsDomainModule))]
    public class BookStoreProDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("ar", "ar", "??????????????", "ae"));
                options.Languages.Add(new LanguageInfo("en", "en", "English", "gb"));
                options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish", "fi"));
                options.Languages.Add(new LanguageInfo("fr", "fr", "Fran??ais", "fr"));
                options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi", "in"));
                options.Languages.Add(new LanguageInfo("it", "it", "Italian", "it"));
                options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak", "sk"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "T??rk??e", "tr"));
                options.Languages.Add(new LanguageInfo("sl", "sl", "Sloven????ina", "si"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "????????????", "cn"));
                options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsche", "de"));
                options.Languages.Add(new LanguageInfo("es", "es", "Espa??ol", "es"));
            });
            Configure<NewsletterOptions>(options =>
            {
                options.AddPreference(
                    "Newsletter_Default",
                    new NewsletterPreferenceDefinition(
                        LocalizableString.Create<BookStoreProResource>("NewsletterPreference_Default"),
                        privacyPolicyConfirmation: LocalizableString.Create<BookStoreProResource>("NewsletterPrivacyAcceptMessage")
                    )
                );
            });
            

#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
