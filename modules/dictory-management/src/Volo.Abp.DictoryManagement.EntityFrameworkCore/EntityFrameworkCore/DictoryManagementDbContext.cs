using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpDictoryManagementDbProperties.ConnectionStringName)]
    public class DictoryManagementDbContext : AbpDbContext<DictoryManagementDbContext>, IDictoryManagementDbContext
    {
        public DbSet<Dictory> Dictory { get; set; }

        public DbSet<DataItem> DataItems { get; set; }

        public DictoryManagementDbContext(DbContextOptions<DictoryManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureDictoryManagement();
        }
    }
}