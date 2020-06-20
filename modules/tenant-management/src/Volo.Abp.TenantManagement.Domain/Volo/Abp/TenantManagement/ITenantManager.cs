using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.TenantManagement
{
    public interface ITenantManager : IDomainService
    {
        [NotNull]
        Task<Tenant> CreateAsync([NotNull] string name);

        Task ChangeNameAsync([NotNull] Tenant tenant, [NotNull] string name);

        void ChangeState([NotNull] Tenant tenant, TenantState state);

        void AddBalance([NotNull] Tenant tenant, decimal amount);

        void AddTotalAmount([NotNull] Tenant tenant, decimal amount);

        void ChangeApplicationState([NotNull] Tenant tenant, Guid editionId, ApplicationState state);

        void AddApplicationUserCount([NotNull] Tenant tenant, Guid editionId, int count);

        void AddApplicationDays([NotNull] Tenant tenant, Guid editionId, int count);

        void AddApplicationMonths([NotNull] Tenant tenant, Guid editionId, int count);

        void AddApplicationTotalMonths([NotNull] Tenant tenant, Guid editionId, int count);

        void AddApplicationTotalAmount([NotNull] Tenant tenant, Guid editionId, decimal amount);
    }
}
