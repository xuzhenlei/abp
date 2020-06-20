using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    public class DictoryManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public DictoryManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}