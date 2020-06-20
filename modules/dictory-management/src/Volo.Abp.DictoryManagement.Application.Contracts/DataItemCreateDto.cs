using System;

namespace Volo.Abp.DictoryManagement
{
    public class DataItemCreateDto: DataItemCreateOrUpdateDtoBase
    {
        public virtual Guid DictoryId { get; set; }
    }
}
