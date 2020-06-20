using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Abp.DictoryManagement.MongoDB
{
    [ConnectionStringName(AbpDictoryManagementDbProperties.ConnectionStringName)]
    public class DictoryManagementMongoDbContext : AbpMongoDbContext, IDictoryManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDictoryManagement();
        }
    }
}