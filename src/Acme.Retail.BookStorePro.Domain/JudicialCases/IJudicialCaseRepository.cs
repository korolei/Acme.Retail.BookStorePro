using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public interface IJudicialCaseRepository : IRepository<JudicialCase, Guid>
    {
        Task<JudicialCaseWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<JudicialCaseWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            Guid? partyId = null,
            Guid? judicialCaseAttributesId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<JudicialCase>> GetListAsync(
                    string filterText = null,
                    string caseNumber = null,
                    string caseName = null,
                    string status = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string caseNumber = null,
            string caseName = null,
            string status = null,
            Guid? partyId = null,
            Guid? judicialCaseAttributesId = null,
            CancellationToken cancellationToken = default);
    }
}