using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.Retail.BookStorePro.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.Retail.BookStorePro.EntityFrameworkCore
{
    public class EntityFrameworkCoreBookStoreProDbSchemaMigrator
        : IBookStoreProDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreBookStoreProDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the BookStoreProDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<BookStoreProDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
