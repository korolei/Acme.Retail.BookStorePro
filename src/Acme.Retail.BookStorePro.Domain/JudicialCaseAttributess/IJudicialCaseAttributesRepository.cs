using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public interface IJudicialCaseAttributesRepository : IRepository<JudicialCaseAttributes, Guid>
    {
        Task<List<JudicialCaseAttributes>> GetListAsync(
            string filterText = null,
            string key = null,
            string value = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string key = null,
            string value = null,
            CancellationToken cancellationToken = default);
    }
}