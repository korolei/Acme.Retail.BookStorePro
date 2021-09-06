using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class JudicialCaseAttributesCreateDto
    {
        [Required]
        [StringLength(JudicialCaseAttributesConsts.KeyMaxLength, MinimumLength = JudicialCaseAttributesConsts.KeyMinLength)]
        public string Key { get; set; }
        [StringLength(JudicialCaseAttributesConsts.ValueMaxLength)]
        public string Value { get; set; }
    }
}