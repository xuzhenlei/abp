using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.Application.Services;

namespace Volo.Abp.AuditLogging
{
    public abstract class AuditLoggingAppServiceBase : ApplicationService
    {
        protected AuditLoggingAppServiceBase()
        {
            LocalizationResource = typeof(AuditLoggingResource);
            ObjectMapperContext = typeof(AbpAuditLoggingApplicationModule);
        }
    }
}
