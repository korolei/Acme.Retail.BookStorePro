using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Acme.Retail.BookStorePro.EntityFrameworkCore;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class EfCoreJudicialCaseAttributesRepository : EfCoreRepository<BookStoreProDbContext, JudicialCaseAttributes, Guid>, IJudicialCaseAttributesRepository
    {
        public EfCoreJudicialCaseAttributesRepository(IDbContextProvider<BookStoreProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<JudicialCaseAttributes>> GetListAsync(
            string filterText = null,
            string key = null,
            string value = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, key, value);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? JudicialCaseAttributesConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string key = null,
            string value = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, key, value);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<JudicialCaseAttributes> ApplyFilter(
            IQueryable<JudicialCaseAttributes> query,
            string filterText,
            string key = null,
            string value = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Key.Contains(filterText) || e.Value.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(key), e => e.Key.Contains(key))
                    .WhereIf(!string.IsNullOrWhiteSpace(value), e => e.Value.Contains(value));
        }
    }
}