using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement
{
    [DependsOn(
        typeof(AbpDictoryManagementDomainSharedModule)
        )]
    public class AbpDictoryManagementDomainModule : AbpModule
    {

    }
}
