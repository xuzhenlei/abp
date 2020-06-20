using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Volo.Abp.DictoryManagement
{
    public interface IDictoryAppService : IApplicationService
    {
        Task<DictoryDto> GetAsync(string code);

        Task<List<DictoryDto>> GetListAsync(Guid? parentId);

        Task<DataItemDto> GetItemAsync(Guid id);

        Task<DataItemDto> CreateItemAsync(DataItemCreateDto input);

        Task<DataItemDto> UpdateItemAsync(Guid id, DataItemUpdateDto input);

        Task RemoveItemAsync(string ids);
    }
}
