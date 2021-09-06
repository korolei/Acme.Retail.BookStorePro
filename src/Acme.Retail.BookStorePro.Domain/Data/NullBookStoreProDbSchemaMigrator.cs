using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Acme.Retail.BookStorePro.Data
{
    /* This is used if database provider does't define
     * IBookStoreProDbSchemaMigrator implementation.
     */
    public class NullBookStoreProDbSchemaMigrator : IBookStoreProDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}