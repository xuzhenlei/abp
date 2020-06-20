using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Abp.EditionManagement
{
    public abstract class EditionManagementAppServiceBase : ApplicationService
    {
        protected EditionManagementAppServiceBase()
        {
            LocalizationResource = typeof(AbpEditionManagementResource);
            ObjectMapperContext = typeof(AbpEditionManagementApplicationModule);
        }
    }
}
