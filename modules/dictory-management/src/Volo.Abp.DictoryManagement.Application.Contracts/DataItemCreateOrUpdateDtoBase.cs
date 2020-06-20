using System;
using System.ComponentModel.DataAnnotations;

namespace Volo.Abp.DictoryManagement
{
    public abstract class DataItemCreateOrUpdateDtoBase
    {
        public virtual Guid? ParentId { get; set; }

        [Required]
        [StringLength(DictoryConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        public virtual int Sort { get; set; }

        [StringLength(DictoryConsts.MaxCoverImageLength)]
        public virtual string CoverImage { get; set; }

        [StringLength(DictoryConsts.MaxDescriptionLentth)]
        public virtual string Description { get; set; }
    }
}
