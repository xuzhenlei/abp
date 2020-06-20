using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Volo.Abp.DictoryManagement
{
    public interface IDictoryManager : IDomainService
    {
        Task<Dictory> CreateDictAsync(DictoryType type,[NotNull] string code, [NotNull] string name);

        Task ChangeDictCodeAsync([NotNull] Dictory dict, [NotNull] string code);

        Task<DataItem> CreateItemAsync(Guid dictoryId, [NotNull] string name);

        Task ChangeItemNameAsync([NotNull] DataItem item, string name);

        Task ChangeItemParentAsync([NotNull] DataItem item, Guid? parentId);
    }
}
