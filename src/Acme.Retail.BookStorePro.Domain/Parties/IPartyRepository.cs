using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.Retail.BookStorePro.Parties
{
    public interface IPartyRepository : IRepository<Party, Guid>
    {
        Task<List<Party>> GetListAsync(
            string filterText = null,
            string partyType = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string partyType = null,
            string status = null,
            CancellationToken cancellationToken = default);
    }
}