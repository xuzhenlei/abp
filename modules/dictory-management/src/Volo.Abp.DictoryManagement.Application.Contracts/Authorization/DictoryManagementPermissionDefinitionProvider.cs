using Volo.Abp.DictoryManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Volo.Abp.DictoryManagement.Authorization
{
    public class DictoryManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var dictoryManagementGroup = context.AddGroup(DictoryManagementPermissions.GroupName, L("Permission:DictoryManagement"));

            var dictoryPermission = dictoryManagementGroup.AddPermission(DictoryManagementPermissions.Dictory.Default, L("Permission:DictoryManagement"));
            dictoryPermission.AddChild(DictoryManagementPermissions.Dictory.Create, L("Permission:Create"));
            dictoryPermission.AddChild(DictoryManagementPermissions.Dictory.Update, L("Permission:Edit"));
            dictoryPermission.AddChild(DictoryManagementPermissions.Dictory.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpDictoryManagementResource>(name);
        }
    }
}