using Volo.Abp.AuditLogging.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.AuditLogging
{
    public abstract class AuditLoggingControllerBase : AbpController
    {
        protected AuditLoggingControllerBase()
        {
            LocalizationResource = typeof(AuditLoggingResource);
        }
    }
}
