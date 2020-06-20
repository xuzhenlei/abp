using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.AuditLogging
{
    public class AuditLogActionDto: EntityDto<Guid>, IMultiTenant, IHasExtraProperties
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid AuditLogId { get; protected set; }

        public virtual string ServiceName { get; protected set; }

        public virtual string MethodName { get; protected set; }

        public virtual string Parameters { get; protected set; }

        public virtual DateTime ExecutionTime { get; protected set; }

        public virtual int ExecutionDuration { get; protected set; }

        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }
    }
}
