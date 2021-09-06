namespace Acme.Retail.BookStorePro.JudicialCases
{
    public static class JudicialCaseConsts
    {
        private const string DefaultSorting = "{0}CaseNumber asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "JudicialCase." : string.Empty);
        }

        public const int CaseNumberMinLength = 10;
        public const int CaseNumberMaxLength = 20;
        public const int CaseNameMinLength = 10;
        public const int CaseNameMaxLength = 250;
        public const int StatusMinLength = 1;
        public const int StatusMaxLength = 250;
    }
}