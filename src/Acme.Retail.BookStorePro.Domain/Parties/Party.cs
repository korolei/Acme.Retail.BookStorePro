using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Acme.Retail.BookStorePro.Parties
{
    public sealed class Party : FullAuditedAggregateRoot<Guid>
    {
        public string PartyType { get; set; }

        public string Status { get; set; }

        public Party()
        {

        }

        public Party(Guid id, string partyType, string status)
        {
            Id = id;
            Check.NotNull(partyType, nameof(partyType));
            Check.Length(partyType, nameof(partyType), PartyConsts.PartyTypeMaxLength, PartyConsts.PartyTypeMinLength);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), PartyConsts.StatusMaxLength, PartyConsts.StatusMinLength);
            PartyType = partyType;
            Status = status;
        }
    }
}