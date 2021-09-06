using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class JudicialCaseAttributes : Entity<Guid>
    {
        [NotNull]
        public virtual string Key { get; set; }

        [CanBeNull]
        public virtual string Value { get; set; }

        public JudicialCaseAttributes()
        {

        }

        public JudicialCaseAttributes(Guid id, string key, string value)
        {
            Id = id;
            Check.NotNull(key, nameof(key));
            Check.Length(key, nameof(key), JudicialCaseAttributesConsts.KeyMaxLength, JudicialCaseAttributesConsts.KeyMinLength);
            Check.Length(value, nameof(value), JudicialCaseAttributesConsts.ValueMaxLength, 0);
            Key = key;
            Value = value;
        }
    }
}