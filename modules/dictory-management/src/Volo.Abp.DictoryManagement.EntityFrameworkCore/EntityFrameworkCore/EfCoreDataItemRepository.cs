using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    public class EfCoreDataItemRepository : EfCoreRepository<IDictoryManagementDbContext, DataItem, Guid>, IDataItemRepository
    {
        public EfCoreDataItemRepository(IDbContextProvider<IDictoryManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public override IQueryable<DataItem> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }

        public virtual async Task<DataItem> FindByNameAsync(
            Guid dictoryId,
            string name,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryable().IncludeDetails(includeDetails);
            query = query.Where(i => i.DictoryId == dictoryId);
            query = query.Where(i => i.Name == name);
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<DataItem>> GetListAsync(
            Guid dictoryId,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryable().IncludeDetails(includeDetails);
            query = query.Where(i => i.DictoryId == dictoryId);
            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
