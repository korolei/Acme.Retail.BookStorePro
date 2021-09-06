using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Retail.BookStorePro.Parties
{
    public interface IPartiesAppService : IApplicationService
    {
        Task<PagedResultDto<PartyDto>> GetListAsync(GetPartiesInput input);

        Task<PartyDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PartyDto> CreateAsync(PartyCreateDto input);

        Task<PartyDto> UpdateAsync(Guid id, PartyUpdateDto input);
    }
}