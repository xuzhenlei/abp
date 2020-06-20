using Volo.Abp.Reflection;

namespace Volo.Abp.EditionManagement.Authorization
{
    public class EditionManagementPermissions
    {
        public const string GroupName = "AbpEditionManagement";

        public static class Editions
        {
            public const string Default = GroupName + ".Editions";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
            public const string ManageState = Default + ".ManageState";
            public const string ManageFeatures = Default + ".ManageFeatures";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(EditionManagementPermissions));
        }
    }
}