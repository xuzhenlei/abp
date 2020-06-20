using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement
{
    [DependsOn(
        typeof(AbpDictoryManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpDictoryManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
