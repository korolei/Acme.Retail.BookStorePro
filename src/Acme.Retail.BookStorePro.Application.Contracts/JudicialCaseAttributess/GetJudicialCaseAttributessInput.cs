using Volo.Abp.Application.Dtos;
using System;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class GetJudicialCaseAttributessInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        public GetJudicialCaseAttributessInput()
        {

        }
    }
}