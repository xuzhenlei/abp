using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.IdentityServer
{
    public abstract class IdentityServerControllerBase : AbpController
    {
        protected IdentityServerControllerBase()
        {
            LocalizationResource = typeof(AbpIdentityServerResource);
        }
    }
}
