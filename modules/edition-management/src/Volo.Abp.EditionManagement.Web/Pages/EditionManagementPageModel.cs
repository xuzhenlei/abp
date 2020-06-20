using Volo.Abp.EditionManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Abp.EditionManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class EditionManagementPageModel : AbpPageModel
    {
        protected EditionManagementPageModel()
        {
            LocalizationResourceType = typeof(AbpEditionManagementResource);
            ObjectMapperContext = typeof(AbpEditionManagementWebModule);
        }
    }
}