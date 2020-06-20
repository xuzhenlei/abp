using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.DictoryManagement
{
    public class DictoryDto : EntityDto<Guid>
    {
        public virtual DictoryType Type { get; set; }

        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual int Sort { get; set; }

        public virtual string CoverImage { get; set; }

        public virtual string Description { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual List<DictoryDto> Children { get; set; }

        public virtual List<DataItemDto> Items { get; set; }
    }
}
