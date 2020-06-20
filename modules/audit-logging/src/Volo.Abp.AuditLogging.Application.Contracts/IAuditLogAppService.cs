using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.AuditLogging
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<AuditLogDto> GetAsync(Guid id);

        Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogsInput input);
    }
}
