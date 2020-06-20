using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.DictoryManagement.Authorization;

namespace Volo.Abp.DictoryManagement
{
    [Authorize(DictoryManagementPermissions.Dictory.Default)]
    public class DictoryAppService : AbpDictoryManagementAppServiceBase, IDictoryAppService
    {
        protected IDictoryManager DictoryManager { get; }

        protected IDictoryRepository DictRepository { get; }

        protected IDataItemRepository ItemRepository { get; }

        public DictoryAppService(
            IDictoryManager dictoryManager,
            IDictoryRepository dictRepository,
            IDataItemRepository itemRepository)
        {
            DictoryManager = dictoryManager;
            DictRepository = dictRepository;
            ItemRepository = itemRepository;
        }

        public virtual async Task<DictoryDto> GetAsync(string code)
        {
            var dict = await DictRepository.FindByCodeAsync(code);
            if (dict == null) throw new UserFriendlyException($"找不到类别 {code}");
            dict.Items = await ItemRepository.GetListAsync(dict.Id);
            dict.Items = dict.Items.ToTree();//格式化为树形数据
            return ObjectMapper.Map<Dictory, DictoryDto>(dict);
        }

        public virtual async Task<List<DictoryDto>> GetListAsync(Guid? parentId)
        {
            var list = await DictRepository.GetListAsync(parentId, true);
            return ObjectMapper.Map<List<Dictory>, List<DictoryDto>>(list);
        }

        public virtual async Task<DataItemDto> GetItemAsync(Guid id)
        {
            return ObjectMapper.Map<DataItem, DataItemDto>(
                await ItemRepository.GetAsync(id)
            );
        }

        [Authorize(DictoryManagementPermissions.Dictory.Create)]
        public virtual async Task<DataItemDto> CreateItemAsync(DataItemCreateDto input)
        {
            var item = await DictoryManager.CreateItemAsync(input.DictoryId, input.Name);
            await MapToEntityAsync(input, item);//映射数据
            await ItemRepository.InsertAsync(item);
            return ObjectMapper.Map<DataItem, DataItemDto>(item);
        }

        [Authorize(DictoryManagementPermissions.Dictory.Update)]
        public virtual async Task<DataItemDto> UpdateItemAsync(Guid id, DataItemUpdateDto input)
        {
            var item = await ItemRepository.GetAsync(id);
            await DictoryManager.ChangeItemNameAsync(item, input.Name);
            await MapToEntityAsync(input, item);//映射数据
            await ItemRepository.UpdateAsync(item);
            return ObjectMapper.Map<DataItem, DataItemDto>(item);
        }

        protected virtual async Task MapToEntityAsync(DataItemCreateOrUpdateDtoBase input, DataItem item)
        {
            item.Sort = input.Sort;
            item.SetCoverImage(input.CoverImage);
            item.SetDescription(input.Description);
            await DictoryManager.ChangeItemParentAsync(item, input.ParentId);
        }

        [Authorize(DictoryManagementPermissions.Dictory.Delete)]
        public virtual async Task RemoveItemAsync(string ids)
        {
            if (ids.IsNullOrWhiteSpace()) return;
            var idList = ids.Split(',').Select(id => Guid.Parse(id));
            foreach (var id in idList)
            {
                var item = await ItemRepository.GetAsync(id);
                if (item.IsStatic)
                {
                    throw new UserFriendlyException($"{item.Name} 为系统字典，不允许删除");
                }
                if (item.Children.Count > 0)
                {
                    throw new UserFriendlyException($"{item.Name} 中存在子项，请先删除子项或移动子项到其他目录");
                }
                await ItemRepository.DeleteAsync(item);
            }
        }
    }
}
