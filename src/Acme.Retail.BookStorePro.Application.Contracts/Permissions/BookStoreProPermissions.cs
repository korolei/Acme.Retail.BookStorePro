namespace Acme.Retail.BookStorePro.Permissions
{
    public static class BookStoreProPermissions
    {
        public const string GroupName = "BookStorePro";

        public static class Dashboard
        {
            public const string DashboardGroup = GroupName + ".Dashboard";
            public const string Host = DashboardGroup + ".Host";
            public const string Tenant = DashboardGroup + ".Tenant";
        }

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Parties
        {
            public const string Default = GroupName + ".Parties";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Cases
        {
            public const string Default = GroupName + ".Cases";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class JudicialCases
        {
            public const string Default = GroupName + ".JudicialCases";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class JudicialCaseAttributess
        {
            public const string Default = GroupName + ".JudicialCaseAttributess";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}