using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.DictoryManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.DictoryManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class AbpDictoryManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDictoryManagementDomainSharedModule>("Volo.Abp.DictoryManagement");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpDictoryManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/DictoryManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpDictoryManagement", typeof(AbpDictoryManagementResource));
            });
        }
    }
}
