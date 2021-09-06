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

namespace Acme.Retail.BookStorePro.Parties
{
    public class EfCorePartyRepository : EfCoreRepository<BookStoreProDbContext, Party, Guid>, IPartyRepository
    {
        public EfCorePartyRepository(IDbContextProvider<BookStoreProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Party>> GetListAsync(
            string filterText = null,
            string partyType = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, partyType, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PartyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string partyType = null,
            string status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, partyType, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Party> ApplyFilter(
            IQueryable<Party> query,
            string filterText,
            string partyType = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PartyType.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(partyType), e => e.PartyType.Contains(partyType))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}