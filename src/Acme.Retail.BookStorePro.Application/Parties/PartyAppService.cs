using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Acme.Retail.BookStorePro.Permissions;
using Acme.Retail.BookStorePro.Parties;

namespace Acme.Retail.BookStorePro.Parties
{

    [Authorize(BookStoreProPermissions.Parties.Default)]
    public class PartiesAppService : ApplicationService, IPartiesAppService
    {
        private readonly IPartyRepository _partyRepository;

        public PartiesAppService(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public virtual async Task<PagedResultDto<PartyDto>> GetListAsync(GetPartiesInput input)
        {
            var totalCount = await _partyRepository.GetCountAsync(input.FilterText, input.PartyType, input.Status);
            var items = await _partyRepository.GetListAsync(input.FilterText, input.PartyType, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PartyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Party>, List<PartyDto>>(items)
            };
        }

        public virtual async Task<PartyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Party, PartyDto>(await _partyRepository.GetAsync(id));
        }

        [Authorize(BookStoreProPermissions.Parties.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _partyRepository.DeleteAsync(id);
        }

        [Authorize(BookStoreProPermissions.Parties.Create)]
        public virtual async Task<PartyDto> CreateAsync(PartyCreateDto input)
        {

            var party = ObjectMapper.Map<PartyCreateDto, Party>(input);

            party = await _partyRepository.InsertAsync(party, autoSave: true);
            return ObjectMapper.Map<Party, PartyDto>(party);
        }

        [Authorize(BookStoreProPermissions.Parties.Edit)]
        public virtual async Task<PartyDto> UpdateAsync(Guid id, PartyUpdateDto input)
        {

            var party = await _partyRepository.GetAsync(id);
            ObjectMapper.Map(input, party);
            party = await _partyRepository.UpdateAsync(party, autoSave: true);
            return ObjectMapper.Map<Party, PartyDto>(party);
        }
    }
}