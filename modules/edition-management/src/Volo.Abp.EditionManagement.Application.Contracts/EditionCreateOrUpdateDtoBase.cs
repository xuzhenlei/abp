using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.EditionManagement
{
    public abstract class EditionCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(EditionConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        public virtual int UserCount { get; set; }

        public virtual int TrialDayCount { get; set; }

        public virtual decimal TrialAmount { get; set; }

        public virtual decimal FirstAmount { get; set; }

        public virtual decimal MonthlyAmount { get; set; }

        public virtual decimal QuarterlyAmount { get; set; }

        public virtual decimal YearlyAmount { get; set; }

        public virtual decimal PerUserAmount { get; set; }

        public virtual List<StepUserCount> StepUserCounts { get; set; }

        [StringLength(EditionConsts.MaxCoverImageLength)]
        public virtual string CoverImage { get; set; }

        [StringLength(EditionConsts.MaxDescriptionLength)]
        public virtual string Description { get; set; }
    }
}
