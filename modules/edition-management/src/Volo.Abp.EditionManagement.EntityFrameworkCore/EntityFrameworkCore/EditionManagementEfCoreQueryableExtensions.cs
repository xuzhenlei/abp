using System.Linq;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public static class EditionManagementEfCoreQueryableExtensions
    {
        public static IQueryable<Edition> IncludeDetails(this IQueryable<Edition> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable;
        }
    }
}
