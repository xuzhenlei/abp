using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    public static class DictoryManagementEfCoreQueryableExtensions
    {
        public static IQueryable<Dictory> IncludeDetails(this IQueryable<Dictory> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(d => d.Children)
                .OrderBy(d => d.Sort);
        }

        public static IQueryable<DataItem> IncludeDetails(this IQueryable<DataItem> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(d => d.Children)
                .OrderBy(d => d.Sort);
        }
    }
}