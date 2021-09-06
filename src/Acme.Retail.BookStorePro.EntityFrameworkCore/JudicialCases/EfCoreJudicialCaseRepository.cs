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

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class EfCoreJudicialCaseRepository : EfCoreRepository<BookStoreProDbContext, JudicialCase, Guid>, IJudicialCaseRepository
    {
        public EfCoreJudicialCaseRepository(IDbContextProvider<BookStoreProDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<JudicialCaseWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.JudicialCase.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<JudicialCaseWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            Guid? partyId = null,
            Guid? judicialCaseAttributesId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, caseNumber, caseName, status, partyId, judicialCaseAttributesId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? JudicialCaseConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<JudicialCaseWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from judicialCase in (await GetDbSetAsync())
                   join party in (await GetDbContextAsync()).Parties on judicialCase.PartyId equals party.Id into parties
                   from party in parties.DefaultIfEmpty()
                   join judicialCaseAttributes in (await GetDbContextAsync()).JudicialCaseAttributess on judicialCase.JudicialCaseAttributesId equals judicialCaseAttributes.Id into judicialCaseAttributess
                   from judicialCaseAttributes in judicialCaseAttributess.DefaultIfEmpty()

                   select new JudicialCaseWithNavigationProperties
                   {
                       JudicialCase = judicialCase,
                       Party = party,
                       JudicialCaseAttributes = judicialCaseAttributes
                   };
        }

        protected virtual IQueryable<JudicialCaseWithNavigationProperties> ApplyFilter(
            IQueryable<JudicialCaseWithNavigationProperties> query,
            string filterText,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            Guid? partyId = null,
            Guid? judicialCaseAttributesId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.JudicialCase.CaseNumber.Contains(filterText) || e.JudicialCase.CaseName.Contains(filterText) || e.JudicialCase.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(caseNumber), e => e.JudicialCase.CaseNumber.Contains(caseNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(caseName), e => e.JudicialCase.CaseName.Contains(caseName))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.JudicialCase.Status.Contains(status))
                    .WhereIf(partyId != null && partyId != Guid.Empty, e => e.Party != null && e.Party.Id == partyId)
                    .WhereIf(judicialCaseAttributesId != null && judicialCaseAttributesId != Guid.Empty, e => e.JudicialCaseAttributes != null && e.JudicialCaseAttributes.Id == judicialCaseAttributesId);
        }

        public async Task<List<JudicialCase>> GetListAsync(
            string filterText = null,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, caseNumber, caseName, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? JudicialCaseConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            Guid? partyId = null,
            Guid? judicialCaseAttributesId = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, caseNumber, caseName, status, partyId, judicialCaseAttributesId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<JudicialCase> ApplyFilter(
            IQueryable<JudicialCase> query,
            string filterText,
            string caseNumber = null,
            string caseName = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CaseNumber.Contains(filterText) || e.CaseName.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(caseNumber), e => e.CaseNumber.Contains(caseNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(caseName), e => e.CaseName.Contains(caseName))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}