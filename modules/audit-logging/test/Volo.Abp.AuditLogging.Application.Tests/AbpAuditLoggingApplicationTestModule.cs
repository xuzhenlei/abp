using Volo.Abp.Modularity;

namespace Volo.Abp.AuditLogging
{
    [DependsOn(
        typeof(AbpAuditLoggingApplicationModule)
        )]
    public class AbpAuditLoggingApplicationTestModule : AbpModule
    {

    }
}
