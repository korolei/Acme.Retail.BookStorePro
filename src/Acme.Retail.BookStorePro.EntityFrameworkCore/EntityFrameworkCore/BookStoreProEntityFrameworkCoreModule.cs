using Acme.Retail.BookStorePro.JudicialCases;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;
using Acme.Retail.BookStorePro.JudicialCases;
using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.JudicialCases;
using Acme.Retail.BookStorePro.JudicialCases;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;
using Volo.Forms.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;
using Volo.Payment.EntityFrameworkCore;
using Volo.Docs.EntityFrameworkCore;

namespace Acme.Retail.BookStorePro.EntityFrameworkCore
{
    [DependsOn(
        typeof(BookStoreProDomainModule),
        typeof(AbpIdentityProEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpFeatureManagementEntityFrameworkCoreModule),
        typeof(LanguageManagementEntityFrameworkCoreModule),
        typeof(SaasEntityFrameworkCoreModule),
        typeof(TextTemplateManagementEntityFrameworkCoreModule),
        typeof(CmsKitProEntityFrameworkCoreModule),
        typeof(BlobStoringDatabaseEntityFrameworkCoreModule)
        )]
    [DependsOn(typeof(FormsEntityFrameworkCoreModule))]
    [DependsOn(typeof(FileManagementEntityFrameworkCoreModule))]
    [DependsOn(typeof(ChatEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpPaymentEntityFrameworkCoreModule))]
    [DependsOn(typeof(DocsEntityFrameworkCoreModule))]
    public class BookStoreProEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BookStoreProEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BookStoreProDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
                options.AddRepository<JudicialCase, EfCoreJudicialCaseRepository>();

                options.AddRepository<JudicialCase, EfCoreJudicialCaseRepository>();

                options.AddRepository<Party, EfCorePartyRepository>();

                options.AddRepository<Party, Parties.EfCorePartyRepository>();

                options.AddRepository<JudicialCase, JudicialCases.EfCoreJudicialCaseRepository>();

                options.AddRepository<JudicialCaseAttributes, JudicialCaseAttributess.EfCoreJudicialCaseAttributesRepository>();

                options.AddRepository<JudicialCase, JudicialCases.EfCoreJudicialCaseRepository>();

            });

            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also BookStoreProDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        }
    }
}