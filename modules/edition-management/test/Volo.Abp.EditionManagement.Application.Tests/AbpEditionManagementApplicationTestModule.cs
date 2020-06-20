using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpEditionManagementApplicationModule),
        typeof(AbpEditionManagementDomainTestModule)
        )]
    public class AbpEditionManagementApplicationTestModule : AbpModule
    {

    }
}
