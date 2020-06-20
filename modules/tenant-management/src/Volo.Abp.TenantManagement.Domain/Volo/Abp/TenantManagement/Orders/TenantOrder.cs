using System;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TenantManagement.Orders
{
    public class TenantOrder : Entity<Guid>
    {
        public virtual Guid TenantId { get; protected set; }

        public virtual OrderType OrderType { get; protected set; }

        public virtual OrderState OrderState { get; protected set; }

        public virtual PayState PayState { get; protected set; }

        public virtual PayMethod? PayMethod { get; protected set; }

        public virtual DateTime? PayTime { get; protected set; }

        public virtual decimal Amount { get; protected set; }

        public virtual decimal Discount { get; protected set; }

        public virtual decimal PayAmount { get; protected set; }

        public virtual Guid? EditionId { get; protected set; }

        public virtual string Description { get; protected set; }

        protected TenantOrder()
        {

        }

        public TenantOrder(Guid id, Guid tenantId, OrderType type)
        {
            Id = id;
            TenantId = tenantId;
            OrderType = type;
        }

        public virtual void SetOrderState(OrderState state)
        {
            OrderState = state;
        }

        public virtual void SetPayState(PayState state)
        {
            PayState = state;
        }

        public virtual void SetPayMethod(PayMethod method)
        {
            PayMethod = method;
        }

        public virtual void SetPayTime(DateTime time)
        {
            PayTime = time;
        }

        public virtual void SetAmount(decimal amount)
        {
            Amount = amount;
        }

        public virtual void SetDiscount(decimal discount)
        {
            Discount = discount;
        }

        public virtual void SetPayAmount(decimal amount)
        {
            PayAmount = amount;
        }

        public virtual void SetApplication(Guid applicationId)
        {
            EditionId = applicationId;
        }
    }
}
