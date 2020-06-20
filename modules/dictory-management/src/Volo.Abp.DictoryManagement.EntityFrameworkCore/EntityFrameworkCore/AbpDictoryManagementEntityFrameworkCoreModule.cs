using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpDictoryManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpDictoryManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DictoryManagementDbContext>(options =>
            {
                options.AddRepository<Dictory, EfCoreDictoryRepository>();
                options.AddRepository<DataItem, EfCoreDataItemRepository>();
            });
        }
    }
}