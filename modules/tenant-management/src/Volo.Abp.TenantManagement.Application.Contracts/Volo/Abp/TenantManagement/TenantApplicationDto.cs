using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class TenantApplicationDto : EntityDto
    {
        public virtual Guid EditionId { get; set; }

        public virtual string EditionName { get; set; }

        public virtual ApplicationState State { get; set; }

        public virtual int UserCount { get; set; }

        public virtual DateTime ExpireTime { get; set; }

        public virtual int TotalMonth { get; set; }

        public virtual decimal TotalAmount { get; set; }
    }
}
