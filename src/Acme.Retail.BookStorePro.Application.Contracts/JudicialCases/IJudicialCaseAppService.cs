using Acme.Retail.BookStorePro.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public interface IJudicialCasesAppService : IApplicationService
    {
        Task<PagedResultDto<JudicialCaseWithNavigationPropertiesDto>> GetListAsync(GetJudicialCasesInput input);

        Task<JudicialCaseWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<JudicialCaseDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartyLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid?>>> GetJudicialCaseAttributesLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<JudicialCaseDto> CreateAsync(JudicialCaseCreateDto input);

        Task<JudicialCaseDto> UpdateAsync(Guid id, JudicialCaseUpdateDto input);
    }
}