using Volo.Abp.DictoryManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(AbpDictoryManagementEntityFrameworkCoreTestModule)
        )]
    public class AbpDictoryManagementDomainTestModule : AbpModule
    {
        
    }
}
