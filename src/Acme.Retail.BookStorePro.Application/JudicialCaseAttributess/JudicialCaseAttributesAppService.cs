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
using Acme.Retail.BookStorePro.JudicialCaseAttributess;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{

    [Authorize(BookStoreProPermissions.JudicialCaseAttributess.Default)]
    public class JudicialCaseAttributessAppService : ApplicationService, IJudicialCaseAttributessAppService
    {
        private readonly IJudicialCaseAttributesRepository _judicialCaseAttributesRepository;

        public JudicialCaseAttributessAppService(IJudicialCaseAttributesRepository judicialCaseAttributesRepository)
        {
            _judicialCaseAttributesRepository = judicialCaseAttributesRepository;
        }

        public virtual async Task<PagedResultDto<JudicialCaseAttributesDto>> GetListAsync(GetJudicialCaseAttributessInput input)
        {
            var totalCount = await _judicialCaseAttributesRepository.GetCountAsync(input.FilterText, input.Key, input.Value);
            var items = await _judicialCaseAttributesRepository.GetListAsync(input.FilterText, input.Key, input.Value, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<JudicialCaseAttributesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<JudicialCaseAttributes>, List<JudicialCaseAttributesDto>>(items)
            };
        }

        public virtual async Task<JudicialCaseAttributesDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<JudicialCaseAttributes, JudicialCaseAttributesDto>(await _judicialCaseAttributesRepository.GetAsync(id));
        }

        [Authorize(BookStoreProPermissions.JudicialCaseAttributess.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _judicialCaseAttributesRepository.DeleteAsync(id);
        }

        [Authorize(BookStoreProPermissions.JudicialCaseAttributess.Create)]
        public virtual async Task<JudicialCaseAttributesDto> CreateAsync(JudicialCaseAttributesCreateDto input)
        {

            var judicialCaseAttributes = ObjectMapper.Map<JudicialCaseAttributesCreateDto, JudicialCaseAttributes>(input);

            judicialCaseAttributes = await _judicialCaseAttributesRepository.InsertAsync(judicialCaseAttributes, autoSave: true);
            return ObjectMapper.Map<JudicialCaseAttributes, JudicialCaseAttributesDto>(judicialCaseAttributes);
        }

        [Authorize(BookStoreProPermissions.JudicialCaseAttributess.Edit)]
        public virtual async Task<JudicialCaseAttributesDto> UpdateAsync(Guid id, JudicialCaseAttributesUpdateDto input)
        {

            var judicialCaseAttributes = await _judicialCaseAttributesRepository.GetAsync(id);
            ObjectMapper.Map(input, judicialCaseAttributes);
            judicialCaseAttributes = await _judicialCaseAttributesRepository.UpdateAsync(judicialCaseAttributes, autoSave: true);
            return ObjectMapper.Map<JudicialCaseAttributes, JudicialCaseAttributesDto>(judicialCaseAttributes);
        }
    }
}