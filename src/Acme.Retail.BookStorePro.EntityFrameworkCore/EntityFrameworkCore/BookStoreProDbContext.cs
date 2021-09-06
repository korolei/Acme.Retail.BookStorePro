using Acme.Retail.BookStorePro.JudicialCaseAttributess;
using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.JudicialCases;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Payment.EntityFrameworkCore;
using Volo.CmsKit.EntityFrameworkCore;
using Volo.Forms.EntityFrameworkCore;
using Volo.FileManagement.EntityFrameworkCore;
using Volo.Chat.EntityFrameworkCore;
using Volo.Docs.EntityFrameworkCore;

namespace Acme.Retail.BookStorePro.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityProDbContext))]
    [ReplaceDbContext(typeof(ISaasDbContext))]
    [ConnectionStringName("Default")]
    public class BookStoreProDbContext :
        AbpDbContext<BookStoreProDbContext>,
        IIdentityProDbContext,
        ISaasDbContext
    {
        public DbSet<JudicialCaseAttributes> JudicialCaseAttributess { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<JudicialCase> JudicialCases { get; set; }
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityProDbContext and ISaasDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        // Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }

        // SaaS
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public BookStoreProDbContext(DbContextOptions<BookStoreProDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentityPro();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureLanguageManagement();
            builder.ConfigurePayment();
            builder.ConfigureSaas();
            builder.ConfigureTextTemplateManagement();
            builder.ConfigureBlobStoring();
            builder.ConfigureCmsKit();
            builder.ConfigureCmsKitPro();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BookStoreProConsts.DbTablePrefix + "YourEntities", BookStoreProConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            if (builder.IsHostDatabase())
            {

            }
            builder.ConfigureForms();
            builder.ConfigureFileManagement();
            builder.ConfigureChat();
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<Party>(b =>
    {
        b.ToTable(BookStoreProConsts.DbTablePrefix + "Parties", BookStoreProConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.PartyType).HasColumnName(nameof(Party.PartyType)).IsRequired().HasMaxLength(PartyConsts.PartyTypeMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(Party.Status)).IsRequired().HasMaxLength(PartyConsts.StatusMaxLength);
    });

            }
            if (builder.IsHostDatabase())
            {

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<JudicialCaseAttributes>(b =>
    {
        b.ToTable(BookStoreProConsts.DbTablePrefix + "JudicialCaseAttributess", BookStoreProConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.Key).HasColumnName(nameof(JudicialCaseAttributes.Key)).IsRequired().HasMaxLength(JudicialCaseAttributesConsts.KeyMaxLength);
        b.Property(x => x.Value).HasColumnName(nameof(JudicialCaseAttributes.Value)).HasMaxLength(JudicialCaseAttributesConsts.ValueMaxLength);
    });

            }
            if (builder.IsHostDatabase())
            {
                builder.Entity<JudicialCase>(b =>
    {
        b.ToTable(BookStoreProConsts.DbTablePrefix + "JudicialCases", BookStoreProConsts.DbSchema);
        b.ConfigureByConvention();
        b.Property(x => x.CaseNumber).HasColumnName(nameof(JudicialCase.CaseNumber)).IsRequired().HasMaxLength(JudicialCaseConsts.CaseNumberMaxLength);
        b.Property(x => x.CaseName).HasColumnName(nameof(JudicialCase.CaseName)).IsRequired().HasMaxLength(JudicialCaseConsts.CaseNameMaxLength);
        b.Property(x => x.Status).HasColumnName(nameof(JudicialCase.Status)).IsRequired().HasMaxLength(JudicialCaseConsts.StatusMaxLength);
        b.HasOne<Party>().WithMany().IsRequired().HasForeignKey(x => x.PartyId);
        b.HasOne<JudicialCaseAttributes>().WithMany().HasForeignKey(x => x.JudicialCaseAttributesId);
    });

            }
            builder.ConfigureDocs();
        }
    }
}