using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement
{
    [DependsOn(
        typeof(AbpDictoryManagementApplicationModule),
        typeof(AbpDictoryManagementDomainTestModule)
        )]
    public class AbpDictoryManagementApplicationTestModule : AbpModule
    {

    }
}
