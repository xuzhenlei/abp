using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Volo.Abp.DictoryManagement
{
    public class DictoryDataSeeder : IDictoryDataSeeder, ITransientDependency
    {
        protected ICurrentTenant CurrentTenant { get; }

        protected IGuidGenerator GuidGenerator { get; }

        protected IDictoryManager DictoryManager { get; }

        protected IDictoryRepository DictRepository { get; }

        public DictoryDataSeeder(
            ICurrentTenant currentTenant,
            IGuidGenerator guidGenerator,
            IDictoryManager dictoryManager,
            IDictoryRepository dictRepository)
        {
            CurrentTenant = currentTenant;
            GuidGenerator = guidGenerator;
            DictoryManager = dictoryManager;
            DictRepository = dictRepository;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(Guid? tenantId = null)
        {
            Dictory dict;
            using (CurrentTenant.Change(tenantId))
            {
                //行业
                dict = await DictRepository.FindByCodeAsync(DictoryNames.Industry, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.枚举, DictoryNames.Industry, "行业");
                    await DictRepository.InsertAsync(dict);
                }

                //区域
                dict = await DictRepository.FindByCodeAsync(DictoryNames.Region, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.树状, DictoryNames.Region, "区域");
                    await DictRepository.InsertAsync(dict);
                }

                //学历
                dict = await DictRepository.FindByCodeAsync(DictoryNames.Education, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.枚举, DictoryNames.Education, "学历");
                    await DictRepository.InsertAsync(dict);
                }

                //结算期限
                dict = await DictRepository.FindByCodeAsync(DictoryNames.SettlementPeriod, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.枚举, DictoryNames.SettlementPeriod, "结算期限");
                    await DictRepository.InsertAsync(dict);
                }

                //结算方式
                dict = await DictRepository.FindByCodeAsync(DictoryNames.SettlementMethod, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.枚举, DictoryNames.SettlementMethod, "结算方式");
                    await DictRepository.InsertAsync(dict);
                }

                //产品分类
                dict = await DictRepository.FindByCodeAsync(DictoryNames.ProductCategory, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.树状, DictoryNames.ProductCategory, "产品分类");
                    await DictRepository.InsertAsync(dict);
                }

                //物料分类
                dict = await DictRepository.FindByCodeAsync(DictoryNames.MaterialCategory, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.树状, DictoryNames.MaterialCategory, "物料分类");
                    await DictRepository.InsertAsync(dict);
                }

                //客户分类
                dict = await DictRepository.FindByCodeAsync(DictoryNames.CustomerCategory, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.树状, DictoryNames.CustomerCategory, "客户分类");
                    await DictRepository.InsertAsync(dict);
                }

                //供应商分类
                dict = await DictRepository.FindByCodeAsync(DictoryNames.SupplierCategory, false);
                if (dict == null)
                {
                    dict = await DictoryManager.CreateDictAsync(DictoryType.树状, DictoryNames.SupplierCategory, "供应商分类");
                    await DictRepository.InsertAsync(dict);
                }
            }
        }
    }
}
