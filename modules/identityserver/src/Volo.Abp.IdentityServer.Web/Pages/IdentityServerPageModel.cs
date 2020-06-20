using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Abp.IdentityServer.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class IdentityServerPageModel : AbpPageModel
    {
        protected IdentityServerPageModel()
        {
            LocalizationResourceType = typeof(AbpIdentityServerResource);
            ObjectMapperContext = typeof(AbpIdentityServerWebModule);
        }
    }
}