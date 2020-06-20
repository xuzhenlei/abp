using Volo.Abp.Reflection;

namespace Volo.Abp.DictoryManagement.Authorization
{
    public class DictoryManagementPermissions
    {
        public const string GroupName = "AbpDictoryManagement";

        public static class Dictory
        {
            public const string Default = GroupName + ".Dictory";
            public const string Create = Default + ".Create";
            public const string Update = Default + ".Update";
            public const string Delete = Default + ".Delete";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DictoryManagementPermissions));
        }
    }
}