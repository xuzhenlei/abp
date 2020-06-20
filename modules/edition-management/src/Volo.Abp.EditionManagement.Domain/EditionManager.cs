using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.EditionManagement
{
    public class EditionManager : DomainService, IEditionManager
    {
        protected IEditionRepository EditionRepository { get; }

        public EditionManager(IEditionRepository editionRepository)
        {
            EditionRepository = editionRepository;
        }

        public virtual async Task<Edition> CreateAsync(string name)
        {
            Check.NotNull(name, nameof(name));
            await ValidateNameAsync(name);
            return new Edition(GuidGenerator.Create(),name);
        }

        public virtual async Task ChangeNameAsync(Edition edition, string name)
        {
            Check.NotNull(edition, nameof(edition));
            Check.NotNull(name, nameof(name));
            await ValidateNameAsync(name, edition.Id);
            edition.SetName(name);
        }

        public virtual void ChangeState(Edition edition, EditionState state)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetState(state);
        }

        public virtual void ChangeUserCount(Edition edition, int count)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetUserCount(count);
        }

        public virtual void ChangeTrialDayCount(Edition edition, int count)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetTrialDayCount(count);
        }

        public virtual void ChangeTrialAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetTrialAmount(amount);
        }

        public virtual void ChangeFirstAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetFirstAmount(amount);
        }

        public virtual void ChangeMonthlyAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetMonthlyAmount(amount);
        }

        public virtual void ChangeQuarterlyAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetQuarterlyAmount(amount);
        }

        public virtual void ChangeYearlyAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetYearlyAmount(amount);
        }

        public virtual void ChangePerUserAmount(Edition edition, decimal amount)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetPerUserAmount(amount);
        }

        public virtual void ChangeStepUserCounts(Edition edition,List<StepUserCount> stepUserCounts)
        {
            Check.NotNull(edition, nameof(edition));
            edition.SetStepUserCounts(stepUserCounts);
        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            var edition = await EditionRepository.FindByNameAsync(name);
            if (edition != null && edition.Id != expectedId)
            {
                throw new UserFriendlyException($"已存在名称为 {name} 的版本");
            }
        }
    }
}
