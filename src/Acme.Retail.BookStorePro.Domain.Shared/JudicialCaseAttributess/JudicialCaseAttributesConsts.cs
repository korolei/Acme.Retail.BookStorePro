namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public static class JudicialCaseAttributesConsts
    {
        private const string DefaultSorting = "{0}Key asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "JudicialCaseAttributes." : string.Empty);
        }

        public const int KeyMinLength = 1;
        public const int KeyMaxLength = 250;
        public const int ValueMaxLength = 250;
    }
}