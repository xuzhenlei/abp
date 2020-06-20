using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Abp.IdentityServer.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Volo.Abp.IdentityServer.Web.Pages.IdentityServerPage
     */
    public abstract class IdentityServerPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AbpIdentityServerResource> L { get; set; }
    }
}
