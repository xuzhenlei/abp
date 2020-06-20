using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.DictoryManagement
{
    public interface IDataItemRepository : IBasicRepository<DataItem, Guid>
    {
        Task<DataItem> FindByNameAsync(
            Guid dictoryId,
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);

        Task<List<DataItem>> GetListAsync(
            Guid dictoryId,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);
    }
}
