using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Retail.BookStorePro.Parties
{
    public class PartyDto : FullAuditedEntityDto<Guid>
    {
        public string PartyType { get; set; }
        public string Status { get; set; }
    }
}