using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Volo.Abp.DictoryManagement.MongoDB
{
    [ConnectionStringName(AbpDictoryManagementDbProperties.ConnectionStringName)]
    public interface IDictoryManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
