﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Volo.Abp.IdentityServer
{
    [DependsOn(
        typeof(AbpIdentityServerApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpIdentityServerHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "AbpIdentityServer";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpIdentityServerApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
