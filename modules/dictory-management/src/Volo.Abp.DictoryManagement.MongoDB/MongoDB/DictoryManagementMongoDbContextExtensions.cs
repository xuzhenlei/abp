using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Volo.Abp.DictoryManagement.MongoDB
{
    public static class DictoryManagementMongoDbContextExtensions
    {
        public static void ConfigureDictoryManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DictoryManagementMongoModelBuilderConfigurationOptions(
                AbpDictoryManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}