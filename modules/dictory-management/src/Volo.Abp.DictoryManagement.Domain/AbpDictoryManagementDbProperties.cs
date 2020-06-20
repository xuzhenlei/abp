using Volo.Abp.Data;

namespace Volo.Abp.DictoryManagement
{
    public static class AbpDictoryManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

        public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

        public const string ConnectionStringName = "AbpDictoryManagement";
    }
}
