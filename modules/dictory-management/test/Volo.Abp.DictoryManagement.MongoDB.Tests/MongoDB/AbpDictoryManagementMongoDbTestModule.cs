using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement.MongoDB
{
    [DependsOn(
        typeof(AbpDictoryManagementTestBaseModule),
        typeof(AbpDictoryManagementMongoDbModule)
        )]
    public class AbpDictoryManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbFixture.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}