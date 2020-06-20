using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    [ConnectionStringName(AbpDictoryManagementDbProperties.ConnectionStringName)]
    public interface IDictoryManagementDbContext : IEfCoreDbContext
    {
        DbSet<Dictory> Dictory { get; }

        DbSet<DataItem> DataItems { get; set; }
    }
}