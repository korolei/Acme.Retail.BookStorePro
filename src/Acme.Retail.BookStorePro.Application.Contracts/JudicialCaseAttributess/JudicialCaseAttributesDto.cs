using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class JudicialCaseAttributesDto : EntityDto<Guid>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}