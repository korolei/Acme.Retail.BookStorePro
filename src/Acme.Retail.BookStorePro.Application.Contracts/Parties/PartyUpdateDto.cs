using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Retail.BookStorePro.Parties
{
    public class PartyUpdateDto
    {
        [Required]
        [StringLength(PartyConsts.PartyTypeMaxLength, MinimumLength = PartyConsts.PartyTypeMinLength)]
        public string PartyType { get; set; }
        [Required]
        [StringLength(PartyConsts.StatusMaxLength, MinimumLength = PartyConsts.StatusMinLength)]
        public string Status { get; set; }
    }
}