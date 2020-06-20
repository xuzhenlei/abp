using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Abp.DictoryManagement
{
    [DependsOn(
        typeof(AbpDictoryManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpDictoryManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpDictoryManagementApplicationContractsModule).Assembly,
                DictoryManagementRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
