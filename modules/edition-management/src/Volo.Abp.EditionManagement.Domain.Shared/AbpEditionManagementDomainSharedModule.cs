using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Volo.Abp.EditionManagement
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class AbpEditionManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpEditionManagementDomainSharedModule>("Volo.Abp.EditionManagement");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpEditionManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/EditionManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("AbpEditionManagement", typeof(AbpEditionManagementResource));
            });
        }
    }
}
