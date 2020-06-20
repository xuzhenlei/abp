using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.EditionManagement
{
    public interface IEditionRepository : IBasicRepository<Edition, Guid>
    {
        Task<Edition> FindByNameAsync(
            string name, 
            bool includeDetails = true, 
            CancellationToken cancellationToken = default);

        Task<List<Edition>> GetListAsync(
            string filter = null,
            string sorting = null, 
            int maxResultCount = int.MaxValue, 
            int skipCount = 0, 
            bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<long> GetCountAsync(
            string filter = null, 
            CancellationToken cancellationToken = default);
    }
}