using System.Threading.Tasks;

namespace Acme.Retail.BookStorePro.Data
{
    public interface IBookStoreProDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}