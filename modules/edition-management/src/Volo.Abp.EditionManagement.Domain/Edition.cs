using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Volo.Abp.Domain.Entities.Auditing;

namespace Volo.Abp.EditionManagement
{
    public class Edition : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual EditionState State { get; protected set; }

        public virtual int UserCount { get; protected set; }

        public virtual int TrialDayCount { get; protected set; }

        public virtual decimal TrialAmount { get; protected set; }

        public virtual decimal FirstAmount { get; protected set; }

        public virtual decimal MonthlyAmount { get; protected set; }

        public virtual decimal QuarterlyAmount { get; protected set; }

        public virtual decimal YearlyAmount { get; protected set; }

        public virtual decimal PerUserAmount { get; protected set; }

        public virtual string StepUserCounts { get; protected set; }

        public virtual string CoverImage { get; set; }

        public virtual string Summary { get; set; }

        public virtual string Description { get; set; }

        protected Edition()
        {

        }

        protected internal Edition(Guid id, [NotNull] string name)
            : base(id)
        {
            SetName(name);
        }

        protected internal virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), EditionConsts.MaxNameLength);
        }

        protected internal virtual void SetState(EditionState state)
        {
            State = state;
        }

        protected internal virtual void SetUserCount(int count)
        {
            UserCount = count;
        }

        protected internal virtual void SetTrialDayCount(int count)
        {
            TrialDayCount = count;
        }

        protected internal virtual void SetTrialAmount(decimal amount)
        {
            TrialAmount = amount;
        }

        protected internal virtual void SetFirstAmount(decimal amount)
        {
            FirstAmount = amount;
        }

        protected internal virtual void SetMonthlyAmount(decimal amount)
        {
            MonthlyAmount = amount;
        }

        protected internal virtual void SetQuarterlyAmount(decimal amount)
        {
            QuarterlyAmount = amount;
        }

        protected internal virtual void SetYearlyAmount(decimal amount)
        {
            YearlyAmount = amount;
        }

        protected internal virtual void SetPerUserAmount(decimal amount)
        {
            PerUserAmount = amount;
        }

        public virtual List<StepUserCount> GetStepUserCounts()
        {
            if (StepUserCounts.IsNullOrWhiteSpace()) return new List<StepUserCount>();
            return JsonConvert.DeserializeObject<List<StepUserCount>>(StepUserCounts);
        }

        protected internal virtual void SetStepUserCounts(List<StepUserCount> stepUserCounts)
        {
            if (stepUserCounts == null) stepUserCounts = new List<StepUserCount>();
            StepUserCounts = JsonConvert.SerializeObject(stepUserCounts);
        }
    }
}
