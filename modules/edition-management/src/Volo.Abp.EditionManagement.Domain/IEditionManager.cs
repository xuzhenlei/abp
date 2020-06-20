using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.EditionManagement
{
    public interface IEditionManager : IDomainService
    {
        [NotNull]
        Task<Edition> CreateAsync([NotNull] string name);

        Task ChangeNameAsync([NotNull] Edition edition, [NotNull] string name);

        void ChangeState([NotNull] Edition edition, EditionState state);

        void ChangeUserCount([NotNull] Edition edition, int count);

        void ChangeTrialDayCount([NotNull] Edition edition, int count);

        void ChangeTrialAmount([NotNull] Edition edition, decimal amount);

        void ChangeFirstAmount([NotNull] Edition edition, decimal amount);

        void ChangeMonthlyAmount([NotNull] Edition edition, decimal amount);

        void ChangeQuarterlyAmount([NotNull] Edition edition, decimal amount);

        void ChangeYearlyAmount([NotNull] Edition edition, decimal amount);

        void ChangePerUserAmount([NotNull] Edition edition, decimal amount);

        void ChangeStepUserCounts([NotNull] Edition edition, [NotNull]List<StepUserCount> stepUserCounts);
    }
}
