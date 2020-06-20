using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.DictoryManagement
{
    public class DataItemDto : EntityDto<Guid>
    {
        public virtual Guid DictoryId { get; set; }

        public virtual string Name { get; set; }

        public virtual int Sort { get; set; }

        public virtual bool IsStatic { get; set; }

        public virtual string CoverImage { get; set; }

        public virtual string Description { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual List<DataItemDto> Children { get; set; }
    }
}
