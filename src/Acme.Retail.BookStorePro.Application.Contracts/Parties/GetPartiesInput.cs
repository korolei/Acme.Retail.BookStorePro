using Volo.Abp.Application.Dtos;
using System;

namespace Acme.Retail.BookStorePro.Parties
{
    public class GetPartiesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string PartyType { get; set; }
        public string Status { get; set; }

        public GetPartiesInput()
        {

        }
    }
}