using System;
using System.Collections.Generic;
using System.Net;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.AuditLogging
{
    public class AuditLogDto : EntityDto<Guid>, IMultiTenant, IHasExtraProperties
    {
        public virtual string ApplicationName { get; set; }

        public virtual Guid? UserId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }

        public virtual string TenantName { get; protected set; }

        public virtual Guid? ImpersonatorUserId { get; protected set; }

        public virtual Guid? ImpersonatorTenantId { get; protected set; }

        public virtual DateTime ExecutionTime { get; protected set; }

        public virtual int ExecutionDuration { get; protected set; }

        public virtual string ClientIpAddress { get; protected set; }

        public virtual string ClientName { get; protected set; }

        public virtual string ClientId { get; set; }

        public virtual string CorrelationId { get; set; }

        public virtual string BrowserInfo { get; protected set; }

        public virtual string HttpMethod { get; protected set; }

        public virtual string Url { get; protected set; }

        public virtual string Exceptions { get; protected set; }

        public virtual string Comments { get; protected set; }

        public virtual int? HttpStatusCode { get; set; }

        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }

        public virtual ICollection<EntityChangeDto> EntityChanges { get; protected set; }

        public virtual ICollection<AuditLogActionDto> Actions { get; protected set; }
    }
}
