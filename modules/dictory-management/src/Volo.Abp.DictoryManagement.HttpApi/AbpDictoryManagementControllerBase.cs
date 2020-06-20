using Volo.Abp.DictoryManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.DictoryManagement
{
    public abstract class AbpDictoryManagementControllerBase : AbpController
    {
        protected AbpDictoryManagementControllerBase()
        {
            LocalizationResource = typeof(AbpDictoryManagementResource);
        }
    }
}
