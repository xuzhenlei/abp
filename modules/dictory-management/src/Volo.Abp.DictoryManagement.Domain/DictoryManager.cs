using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.DictoryManagement
{
    public class DictoryManager : DomainService, IDictoryManager
    {
        protected IDictoryRepository DictRepository { get; }

        protected IDataItemRepository ItemRepository { get; }

        public DictoryManager(
            IDictoryRepository dictRepository,
            IDataItemRepository itemRepository)
        {
            DictRepository = dictRepository;
            ItemRepository = itemRepository;
        }

        public virtual async Task<Dictory> CreateDictAsync(DictoryType type, string code, string name)
        {
            Check.NotNull(code, nameof(code));
            Check.NotNull(name, nameof(name));
            await ValidateDictCodeAsync(code);
            return new Dictory(GuidGenerator.Create(), type, code, name);
        }

        public virtual async Task ChangeDictCodeAsync(Dictory dict, string code)
        {
            Check.NotNull(dict, nameof(dict));
            Check.NotNull(code, nameof(code));
            await ValidateDictCodeAsync(code, dict.Id);
            dict.SetCode(code);
        }

        public virtual async Task<DataItem> CreateItemAsync(Guid dictoryId, string name)
        {
            Check.NotNull(name, nameof(name));
            await ValidateItemNameAsync(dictoryId, name);
            return new DataItem(dictoryId, GuidGenerator.Create(), name);
        }

        public virtual async Task ChangeItemNameAsync(DataItem item, string name)
        {
            Check.NotNull(item, nameof(item));
            Check.NotNull(name, nameof(name));
            await ValidateItemNameAsync(item.DictoryId, name, item.Id);
            item.SetName(name);
        }

        protected virtual async Task ValidateDictCodeAsync(string code, Guid? expectedId = null)
        {
            var dictory = await DictRepository.FindByCodeAsync(code);
            if (dictory != null && dictory.Id != expectedId)
            {
                throw new UserFriendlyException($"已存在代码为 {code} 的类别");
            }
        }

        protected virtual async Task ValidateItemNameAsync(Guid dictoryId, string name, Guid? expectedId = null)
        {
            var item = await ItemRepository.FindByNameAsync(dictoryId, name);
            if (item != null && item.Id != expectedId)
            {
                throw new UserFriendlyException($"已存在名称为 {name} 的字典");
            }
        }

        public virtual async Task ChangeItemParentAsync([NotNull] DataItem item, Guid? parentId)
        {
            var dict = await DictRepository.GetAsync(item.DictoryId);
            if (dict == null) throw new UserFriendlyException($"找不到类别 {item.DictoryId}");
            if (dict.Type == DictoryType.枚举 && parentId.HasValue)
            {
                throw new UserFriendlyException($"类别 {dict.Name} 的为枚举，禁止设置父级");
            }
            item.SetParent(parentId);
        }
    }
}
