using Volo.Abp.Application.Dtos;
using System;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class GetJudicialCasesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string CaseNumber { get; set; }
        public string CaseName { get; set; }
        public string Status { get; set; }
        public Guid? PartyId { get; set; }
        public Guid? JudicialCaseAttributesId { get; set; }

        public GetJudicialCasesInput()
        {

        }
    }
}