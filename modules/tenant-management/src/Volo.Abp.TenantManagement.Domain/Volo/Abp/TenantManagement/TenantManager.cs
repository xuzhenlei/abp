using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.TenantManagement
{
    public class TenantManager : DomainService, ITenantManager
    {
        protected ITenantRepository TenantRepository { get; }

        public TenantManager(ITenantRepository tenantRepository)
        {
            TenantRepository = tenantRepository;

        }

        public virtual async Task<Tenant> CreateAsync(string name)
        {
            Check.NotNull(name, nameof(name));
            await ValidateNameAsync(name);
            return new Tenant(GuidGenerator.Create(), name);
        }

        public virtual async Task ChangeNameAsync(Tenant tenant, string name)
        {
            Check.NotNull(tenant, nameof(tenant));
            Check.NotNull(name, nameof(name));
            await ValidateNameAsync(name, tenant.Id);
            tenant.SetName(name);
        }

        public virtual void ChangeState(Tenant tenant, TenantState state)
        {
            Check.NotNull(tenant, nameof(tenant));
            tenant.SetState(state);
        }

        public virtual void AddBalance(Tenant tenant, decimal amount)
        {
            Check.NotNull(tenant, nameof(tenant));
            var newBalance = tenant.Balance + amount;
            if (newBalance < 0)
            {
                throw new UserFriendlyException("余额不允许小于零");
            }
            tenant.SetBalance(newBalance);
            AddTotalAmount(tenant, amount);
        }

        public virtual void AddTotalAmount(Tenant tenant, decimal amount)
        {
            Check.NotNull(tenant, nameof(tenant));
            var newTotalAmount = tenant.TotalAmount + amount;
            if (newTotalAmount < 0)
            {
                throw new UserFriendlyException("总消费额不允许小于零");
            }
            tenant.SetTotalAmount(newTotalAmount);
        }

        public virtual void ChangeApplicationState(Tenant tenant, Guid editionId, ApplicationState state)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                tenantApplication.SetState(state);
            }
        }

        public virtual void AddApplicationUserCount(Tenant tenant, Guid editionId, int count)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                var newUserCount = tenantApplication.UserCount + count;
                if (newUserCount < 0)
                {
                    throw new UserFriendlyException("用户数量不允许小于零");
                }
                tenantApplication.SetUserCount(newUserCount);
            }
        }

        public virtual void AddApplicationDays(Tenant tenant, Guid editionId, int count)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                DateTime newExpireTime;
                if (tenantApplication.ExpireTime.Date <= Clock.Now.Date)
                {
                    newExpireTime = Clock.Now.Date.AddDays(count);
                }
                else
                {
                    newExpireTime = tenantApplication.ExpireTime.Date.AddDays(count);
                }
                newExpireTime = DateTime.Parse(newExpireTime.Date.ToString("yyyy-MM-dd 23:59:59"));
                tenantApplication.SetExpireTime(newExpireTime);
                AddApplicationTotalMonths(tenant, editionId, 1);
            }
        }

        public virtual void AddApplicationMonths(Tenant tenant, Guid editionId, int count)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                DateTime newExpireTime;
                if (tenantApplication.ExpireTime.Date <= Clock.Now.Date)
                {
                    newExpireTime = Clock.Now.Date.AddMonths(count);
                }
                else
                {
                    newExpireTime = tenantApplication.ExpireTime.Date.AddMonths(count);
                }
                newExpireTime = DateTime.Parse(newExpireTime.Date.ToString("yyyy-MM-dd 23:59:59"));
                tenantApplication.SetExpireTime(newExpireTime);
                AddApplicationTotalMonths(tenant, editionId, count);
            }
        }

        public virtual void AddApplicationTotalMonths(Tenant tenant, Guid editionId, int count)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                var newTotalMonths = tenantApplication.TotalMonth + count;
                if (newTotalMonths < 0)
                {
                    throw new UserFriendlyException("总月数不允许小于零");
                }
                tenantApplication.SetTotalMonth(newTotalMonths);
            }
        }

        public virtual void AddApplicationTotalAmount(Tenant tenant, Guid editionId, decimal amount)
        {
            Check.NotNull(tenant, nameof(tenant));
            var tenantApplication = tenant.Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                var newTotalAmount = tenantApplication.TotalAmount + amount;
                if (newTotalAmount < 0)
                {
                    throw new UserFriendlyException("总消费额不允许小于零");
                }
                tenantApplication.SetTotalAmount(newTotalAmount);
            }
        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            var tenant = await TenantRepository.FindByNameAsync(name);
            if (tenant != null && tenant.Id != expectedId)
            {
                throw new UserFriendlyException($"已存在名称为 {name} 的租户");
            }
        }
    }
}