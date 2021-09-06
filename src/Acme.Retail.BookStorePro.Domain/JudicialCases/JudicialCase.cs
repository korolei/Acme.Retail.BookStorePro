using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCase : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string CaseNumber { get; set; }

        [NotNull]
        public virtual string CaseName { get; set; }

        [NotNull]
        public virtual string Status { get; set; }
        public Guid PartyId { get; set; }
        public Guid? JudicialCaseAttributesId { get; set; }

        public JudicialCase()
        {

        }

        public JudicialCase(Guid id, string caseNumber, string caseName, string status)
        {
            Id = id;
            Check.NotNull(caseNumber, nameof(caseNumber));
            Check.Length(caseNumber, nameof(caseNumber), JudicialCaseConsts.CaseNumberMaxLength, JudicialCaseConsts.CaseNumberMinLength);
            Check.NotNull(caseName, nameof(caseName));
            Check.Length(caseName, nameof(caseName), JudicialCaseConsts.CaseNameMaxLength, JudicialCaseConsts.CaseNameMinLength);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), JudicialCaseConsts.StatusMaxLength, JudicialCaseConsts.StatusMinLength);
            CaseNumber = caseNumber;
            CaseName = caseName;
            Status = status;
        }
    }
}