using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Volo.Abp.DictoryManagement.MongoDB
{
    public class DictoryManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DictoryManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}