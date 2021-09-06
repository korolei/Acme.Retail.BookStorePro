using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCaseDto : FullAuditedEntityDto<Guid>
    {
        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string Status { get; set; }
        public Guid PartyId { get; set; }
        public Guid? JudicialCaseAttributesId { get; set; }
    }
}