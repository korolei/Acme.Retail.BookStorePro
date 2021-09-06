using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCaseWithNavigationProperties
    {
        public JudicialCase JudicialCase { get; set; }

        public Party Party { get; set; }
        public JudicialCaseAttributes JudicialCaseAttributes { get; set; }
        
    }
}