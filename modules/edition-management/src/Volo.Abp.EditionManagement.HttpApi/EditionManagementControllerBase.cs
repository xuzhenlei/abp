using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.EditionManagement
{
    public abstract class EditionManagementControllerBase : AbpController
    {
        protected EditionManagementControllerBase()
        {
            LocalizationResource = typeof(AbpEditionManagementResource);
        }
    }
}
