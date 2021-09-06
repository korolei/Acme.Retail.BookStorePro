using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;

using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCaseWithNavigationPropertiesDto
    {
        public JudicialCaseDto JudicialCase { get; set; }

        public PartyDto Party { get; set; }
        public JudicialCaseAttributesDto JudicialCaseAttributes { get; set; }

    }
}