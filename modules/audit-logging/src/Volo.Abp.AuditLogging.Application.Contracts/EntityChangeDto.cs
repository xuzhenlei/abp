using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.AuditLogging
{
    public class EntityChangeDto : EntityDto<Guid>, IMultiTenant, IHasExtraProperties
    {
        public virtual Guid AuditLogId { get; protected set; }

        public virtual Guid? TenantId { get; protected set; }

        public virtual DateTime ChangeTime { get; protected set; }

        public virtual EntityChangeType ChangeType { get; protected set; }

        public virtual Guid? EntityTenantId { get; protected set; }

        public virtual string EntityId { get; protected set; }

        public virtual string EntityTypeFullName { get; protected set; }

        public virtual Dictionary<string, object> ExtraProperties { get; protected set; }

        public ICollection<EntityPropertyChangeDto> PropertyChanges { get; protected set; }
    }
}
