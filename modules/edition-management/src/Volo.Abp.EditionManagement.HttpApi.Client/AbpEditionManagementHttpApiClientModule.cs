using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpEditionManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpEditionManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpEditionManagementApplicationContractsModule).Assembly,
                EditionManagementRemoteServiceConsts.RemoteServiceName
            );
        }
    }
}
