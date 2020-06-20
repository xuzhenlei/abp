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
    public class EfCoreDictoryRepository : EfCoreRepository<IDictoryManagementDbContext, Dictory, Guid>, IDictoryRepository
    {
        public EfCoreDictoryRepository(IDbContextProvider<IDictoryManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public override IQueryable<Dictory> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }

        public virtual async Task<Dictory> FindByCodeAsync(
            string code,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryable().IncludeDetails(includeDetails);
            query = query.Where(d => d.Code == code);
            return await query.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Dictory>> GetListAsync(
            Guid? parentId = null,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            var query = GetQueryable().IncludeDetails(includeDetails);
            query = query.WhereIf(parentId.HasValue, d => d.ParentId == parentId);
            return await query.ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
