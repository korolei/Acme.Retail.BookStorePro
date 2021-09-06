using Acme.Retail.BookStorePro.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.Retail.BookStorePro.Permissions
{
    public class BookStoreProPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookStoreProPermissions.GroupName);

            myGroup.AddPermission(BookStoreProPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(BookStoreProPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BookStoreProPermissions.MyPermission1, L("Permission:MyPermission1"));

            var partyPermission = myGroup.AddPermission(BookStoreProPermissions.Parties.Default, L("Permission:Parties"));
            partyPermission.AddChild(BookStoreProPermissions.Parties.Create, L("Permission:Create"));
            partyPermission.AddChild(BookStoreProPermissions.Parties.Edit, L("Permission:Edit"));
            partyPermission.AddChild(BookStoreProPermissions.Parties.Delete, L("Permission:Delete"));

            var casePermission = myGroup.AddPermission(BookStoreProPermissions.Cases.Default, L("Permission:Cases"));
            casePermission.AddChild(BookStoreProPermissions.Cases.Create, L("Permission:Create"));
            casePermission.AddChild(BookStoreProPermissions.Cases.Edit, L("Permission:Edit"));
            casePermission.AddChild(BookStoreProPermissions.Cases.Delete, L("Permission:Delete"));

            var judicialCasePermission = myGroup.AddPermission(BookStoreProPermissions.JudicialCases.Default, L("Permission:JudicialCases"));
            judicialCasePermission.AddChild(BookStoreProPermissions.JudicialCases.Create, L("Permission:Create"));
            judicialCasePermission.AddChild(BookStoreProPermissions.JudicialCases.Edit, L("Permission:Edit"));
            judicialCasePermission.AddChild(BookStoreProPermissions.JudicialCases.Delete, L("Permission:Delete"));

            var judicialCaseAttributesPermission = myGroup.AddPermission(BookStoreProPermissions.JudicialCaseAttributess.Default, L("Permission:JudicialCaseAttributess"));
            judicialCaseAttributesPermission.AddChild(BookStoreProPermissions.JudicialCaseAttributess.Create, L("Permission:Create"));
            judicialCaseAttributesPermission.AddChild(BookStoreProPermissions.JudicialCaseAttributess.Edit, L("Permission:Edit"));
            judicialCaseAttributesPermission.AddChild(BookStoreProPermissions.JudicialCaseAttributess.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookStoreProResource>(name);
        }
    }
}