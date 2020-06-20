using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.DictoryManagement
{
    public class DictoryDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected IDictoryDataSeeder DictoryDataSeeder { get; }

        public DictoryDataSeedContributor(IDictoryDataSeeder dictoryDataSeeder)
        {
            DictoryDataSeeder = dictoryDataSeeder;
        }

        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await DictoryDataSeeder.SeedAsync();
        }
    }
}
