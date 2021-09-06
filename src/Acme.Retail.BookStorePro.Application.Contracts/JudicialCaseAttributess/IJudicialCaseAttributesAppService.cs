using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public interface IJudicialCaseAttributessAppService : IApplicationService
    {
        Task<PagedResultDto<JudicialCaseAttributesDto>> GetListAsync(GetJudicialCaseAttributessInput input);

        Task<JudicialCaseAttributesDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<JudicialCaseAttributesDto> CreateAsync(JudicialCaseAttributesCreateDto input);

        Task<JudicialCaseAttributesDto> UpdateAsync(Guid id, JudicialCaseAttributesUpdateDto input);
    }
}