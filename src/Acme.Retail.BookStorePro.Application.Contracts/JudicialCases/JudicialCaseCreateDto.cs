using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCaseCreateDto
    {
        [Required]
        [StringLength(JudicialCaseConsts.CaseNumberMaxLength, MinimumLength = JudicialCaseConsts.CaseNumberMinLength)]
        public string CaseNumber { get; set; }
        [Required]
        [StringLength(JudicialCaseConsts.CaseNameMaxLength, MinimumLength = JudicialCaseConsts.CaseNameMinLength)]
        public string CaseName { get; set; }
        [Required]
        [StringLength(JudicialCaseConsts.StatusMaxLength, MinimumLength = JudicialCaseConsts.StatusMinLength)]
        public string Status { get; set; }
        public Guid PartyId { get; set; }
        public Guid? JudicialCaseAttributesId { get; set; }
    }
}