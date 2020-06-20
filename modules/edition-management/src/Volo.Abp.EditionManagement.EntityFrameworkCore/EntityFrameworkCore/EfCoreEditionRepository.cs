using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public class EfCoreEditionRepository : EfCoreRepository<IEditionManagementDbContext, Edition, Guid>, IEditionRepository
    {
        public EfCoreEditionRepository(IDbContextProvider<IEditionManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<Edition> FindByNameAsync(
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return await DbSet
                .IncludeDetails(includeDetails)
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
            return await DbSet
                .IncludeDetails(includeDetails)
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter)
                )
                .OrderBy(sorting ?? nameof(Edition.Name))
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            string filter = null, 
            CancellationToken cancellationToken = default)
        {
            return await this
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    u => u.Name.Contains(filter)
                ).CountAsync(cancellationToken: cancellationToken);
        }

        public override IQueryable<Edition> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }
    }
}
