using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.EditionManagement
{
    public class EditionDto : ExtensibleEntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual EditionState State { get; set; }

        public virtual int UserCount { get; set; }

        public virtual int TrialDayCount { get; set; }

        public virtual decimal TrialAmount { get; set; }

        public virtual decimal FirstAmount { get; set; }

        public virtual decimal MonthlyAmount { get; set; }

        public virtual decimal QuarterlyAmount { get; set; }

        public virtual decimal YearlyAmount { get; set; }

        public virtual decimal PerUserAmount { get; set; }

        public virtual List<StepUserCount> StepUserCounts { get; set; }

        public virtual string CoverImage { get; set; }

        public virtual string Description { get; set; }
    }
}
