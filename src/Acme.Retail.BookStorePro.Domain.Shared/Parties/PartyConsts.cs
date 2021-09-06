namespace Acme.Retail.BookStorePro.Parties
{
    public static class PartyConsts
    {
        private const string DefaultSorting = "{0}PartyType asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Party." : string.Empty);
        }

        public const int PartyTypeMinLength = 1;
        public const int PartyTypeMaxLength = 250;
        public const int StatusMinLength = 1;
        public const int StatusMaxLength = 50;
    }
}