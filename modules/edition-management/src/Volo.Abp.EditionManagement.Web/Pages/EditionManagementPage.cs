using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Abp.EditionManagement.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Volo.Abp.EditionManagement.Web.Pages.EditionManagementPage
     */
    public abstract class EditionManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AbpEditionManagementResource> L { get; set; }
    }
}
