using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Volo.Abp.AuditLogging
{
    [RemoteService]
    [Route("api/audit-logging/audit-logs")]
    public class AuditLogsController : AuditLoggingControllerBase, IAuditLogAppService
    {
        private readonly IAuditLogAppService _service;

        public AuditLogsController(IAuditLogAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        [DisableAuditing]
        public virtual Task<AuditLogDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [DisableAuditing]
        public virtual Task<PagedResultDto<AuditLogDto>> GetListAsync(GetAuditLogsInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}
