using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.EditionManagement.Authorization
{
    public class EditionManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var editionManagementGroup = context.AddGroup(EditionManagementPermissions.GroupName, L("Permission:EditionManagement"));

            var editionsPermission = editionManagementGroup.AddPermission(EditionManagementPermissions.Editions.Default, L("Permission:EditionManagement"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissions.Editions.Create, L("Permission:Create"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissions.Editions.Update, L("Permission:Edit"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissions.Editions.Delete, L("Permission:Delete"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissions.Editions.ManageState, L("Permission:ManageState"), multiTenancySide: MultiTenancySides.Host);
            editionsPermission.AddChild(EditionManagementPermissions.Editions.ManageFeatures, L("Permission:ManageFeatures"), multiTenancySide: MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpEditionManagementResource>(name);
        }
    }
}