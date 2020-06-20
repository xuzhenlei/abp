using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using System.Linq;
using System.Linq.Dynamic.Core;
using MongoDB.Driver;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Volo.Abp.EditionManagement.MongoDB
{
    public class MongoEditionRepository : MongoDbRepository<IEditionManagementMongoDbContext, Edition, Guid>, IEditionRepository
    {
        public MongoEditionRepository(IMongoDbContextProvider<IEditionManagementMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<Edition> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(t => t.Name == name, GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Edition>> GetListAsync(
            string filter = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .WhereIf<Edition, IMongoQueryable<Edition>>(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(Edition.Name))
                .As<IMongoQueryable<Edition>>()
                .PageBy<Edition, IMongoQueryable<Edition>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .WhereIf<Edition, IMongoQueryable<Edition>>(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter)
                ).CountAsync(cancellationToken: cancellationToken);
        }
    }
}