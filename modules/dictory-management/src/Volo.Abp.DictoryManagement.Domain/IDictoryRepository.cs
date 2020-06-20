using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.DictoryManagement
{
    public interface IDictoryRepository : IBasicRepository<Dictory, Guid>
    {
        Task<Dictory> FindByCodeAsync(
            string code,
            bool includeDetails = true,
            CancellationToken cancellationToken = default);

        Task<List<Dictory>> GetListAsync(
            Guid? parentId = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default);
    }
}
