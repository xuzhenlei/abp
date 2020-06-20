using System;
using System.Threading.Tasks;

namespace Volo.Abp.DictoryManagement
{
    public interface IDictoryDataSeeder
    {
        Task SeedAsync(
            Guid? tenantId = null);
    }
}
