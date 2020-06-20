using System;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TenantManagement
{
    public class TenantApplication : Entity
    {
        public virtual Guid TenantId { get; protected set; }

        public virtual Guid EditionId { get; protected set; }

        public virtual ApplicationState State { get; protected set; }

        public virtual int UserCount { get; protected set; }

        public virtual DateTime ExpireTime { get; protected set; }

        public virtual int TotalMonth { get; protected set; }

        public virtual decimal TotalAmount { get; protected set; }

        protected TenantApplication()
        {

        }

        protected internal TenantApplication(Guid tenantId, Guid editionId, ApplicationState state)
        {
            TenantId = tenantId;
            EditionId = editionId;
            State = state;
        }

        protected internal virtual void SetState(ApplicationState state)
        {
            State = state;
        }

        protected internal virtual void SetUserCount(int count)
        {
            UserCount = count;
        }

        protected internal virtual void SetExpireTime(DateTime time)
        {
            ExpireTime = time;
        }

        protected internal virtual void SetTotalMonth(int count)
        {
            TotalMonth = count;
        }

        protected internal virtual void SetTotalAmount(decimal amount)
        {
            TotalAmount = amount;
        }

        public override object[] GetKeys()
        {
            return new object[] { TenantId, EditionId };
        }
    }
}
