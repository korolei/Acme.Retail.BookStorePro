using Acme.Retail.BookStorePro.Shared;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;
using Acme.Retail.BookStorePro.Parties;
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
using Acme.Retail.BookStorePro.JudicialCases;

namespace Acme.Retail.BookStorePro.JudicialCases
{

    [Authorize(BookStoreProPermissions.JudicialCases.Default)]
    public class JudicialCasesAppService : ApplicationService, IJudicialCasesAppService
    {
        private readonly IJudicialCaseRepository _judicialCaseRepository;
        private readonly IRepository<Party, Guid> _partyRepository;
        private readonly IRepository<JudicialCaseAttributes, Guid> _judicialCaseAttributesRepository;

        public JudicialCasesAppService(IJudicialCaseRepository judicialCaseRepository, IRepository<Party, Guid> partyRepository, IRepository<JudicialCaseAttributes, Guid> judicialCaseAttributesRepository)
        {
            _judicialCaseRepository = judicialCaseRepository; _partyRepository = partyRepository;
            _judicialCaseAttributesRepository = judicialCaseAttributesRepository;
        }

        public virtual async Task<PagedResultDto<JudicialCaseWithNavigationPropertiesDto>> GetListAsync(GetJudicialCasesInput input)
        {
            var totalCount = await _judicialCaseRepository.GetCountAsync(input.FilterText, input.CaseNumber, input.CaseName, input.Status, input.PartyId, input.JudicialCaseAttributesId);
            var items = await _judicialCaseRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.CaseNumber, input.CaseName, input.Status, input.PartyId, input.JudicialCaseAttributesId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<JudicialCaseWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<JudicialCaseWithNavigationProperties>, List<JudicialCaseWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<JudicialCaseWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<JudicialCaseWithNavigationProperties, JudicialCaseWithNavigationPropertiesDto>
                (await _judicialCaseRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<JudicialCaseDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<JudicialCase, JudicialCaseDto>(await _judicialCaseRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPartyLookupAsync(LookupRequestDto input)
        {
            var query = _partyRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.PartyType != null &&
                         x.PartyType.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Party>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Party>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetJudicialCaseAttributesLookupAsync(LookupRequestDto input)
        {
            var query = _judicialCaseAttributesRepository.AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Key != null &&
                         x.Key.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<JudicialCaseAttributes>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<JudicialCaseAttributes>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(BookStoreProPermissions.JudicialCases.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _judicialCaseRepository.DeleteAsync(id);
        }

        [Authorize(BookStoreProPermissions.JudicialCases.Create)]
        public virtual async Task<JudicialCaseDto> CreateAsync(JudicialCaseCreateDto input)
        {
            if (input.PartyId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Party"]]);
            }

            var judicialCase = ObjectMapper.Map<JudicialCaseCreateDto, JudicialCase>(input);

            judicialCase = await _judicialCaseRepository.InsertAsync(judicialCase, autoSave: true);
            return ObjectMapper.Map<JudicialCase, JudicialCaseDto>(judicialCase);
        }

        [Authorize(BookStoreProPermissions.JudicialCases.Edit)]
        public virtual async Task<JudicialCaseDto> UpdateAsync(Guid id, JudicialCaseUpdateDto input)
        {
            if (input.PartyId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Party"]]);
            }

            var judicialCase = await _judicialCaseRepository.GetAsync(id);
            ObjectMapper.Map(input, judicialCase);
            judicialCase = await _judicialCaseRepository.UpdateAsync(judicialCase, autoSave: true);
            return ObjectMapper.Map<JudicialCase, JudicialCaseDto>(judicialCase);
        }
    }
}