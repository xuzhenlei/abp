using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Abp.IdentityServer
{
    public abstract class IdentityServerAppServiceBase : ApplicationService
    {
        protected IdentityServerAppServiceBase()
        {
            LocalizationResource = typeof(AbpIdentityServerResource);
            ObjectMapperContext = typeof(AbpIdentityServerApplicationModule);
        }
    }
}
