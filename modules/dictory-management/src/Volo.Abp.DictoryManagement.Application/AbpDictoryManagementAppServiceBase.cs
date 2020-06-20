using Volo.Abp.DictoryManagement.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Abp.DictoryManagement
{
    public abstract class AbpDictoryManagementAppServiceBase : ApplicationService
    {
        protected AbpDictoryManagementAppServiceBase()
        {
            LocalizationResource = typeof(AbpDictoryManagementResource);
            ObjectMapperContext = typeof(AbpDictoryManagementApplicationModule);
        }
    }
}
