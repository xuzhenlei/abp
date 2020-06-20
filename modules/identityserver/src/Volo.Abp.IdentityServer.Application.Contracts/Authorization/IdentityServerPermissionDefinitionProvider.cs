using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Volo.Abp.IdentityServer.Authorization
{
    public class IdentityServerPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var identityServerGroup = context.AddGroup(IdentityServerPermissions.GroupName, L("Permission:IdentityServer"));

            var clientsPermission = identityServerGroup.AddPermission(IdentityServerPermissions.Clients.Default, L("Permission:Clients"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Create, L("Permission:Create"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Update, L("Permission:Update"));
            clientsPermission.AddChild(IdentityServerPermissions.Clients.Delete, L("Permission:Delete"));

            var apiResourcesPermission = identityServerGroup.AddPermission(IdentityServerPermissions.ApiResources.Default, L("Permission:ApiResources"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Create, L("Permission:Create"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Update, L("Permission:Update"));
            apiResourcesPermission.AddChild(IdentityServerPermissions.ApiResources.Delete, L("Permission:Delete"));

            var identityResourcesPermission = identityServerGroup.AddPermission(IdentityServerPermissions.IdentityResources.Default, L("Permission:IdentityResources"));
            identityResourcesPermission.AddChild(IdentityServerPermissions.IdentityResources.Create, L("Permission:Create"));
            identityResourcesPermission.AddChild(IdentityServerPermissions.IdentityResources.Update, L("Permission:Update"));
            identityResourcesPermission.AddChild(IdentityServerPermissions.IdentityResources.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpIdentityServerResource>(name);
        }
    }
}