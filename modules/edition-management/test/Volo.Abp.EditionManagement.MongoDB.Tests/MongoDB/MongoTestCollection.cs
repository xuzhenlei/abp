using Xunit;

namespace Volo.Abp.EditionManagement.MongoDB
{
    [CollectionDefinition(Name)]
    public class MongoTestCollection : ICollectionFixture<MongoDbFixture>
    {
        public const string Name = "MongoDB Collection";
    }
}