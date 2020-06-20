using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Abp.AuditLogging.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Volo.Abp.AuditLogging.Web.Pages.AuditLoggingPage
     */
    public abstract class AuditLoggingPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AuditLoggingResource> L { get; set; }
    }
}
