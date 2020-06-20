﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.TenantManagement
{
    [Authorize(TenantManagementPermissions.Tenants.Default)]
    public class TenantAppService : TenantManagementAppServiceBase, ITenantAppService
    {
        protected IDataSeeder DataSeeder { get; }
        protected ITenantRepository TenantRepository { get; }
        protected ITenantManager TenantManager { get; }

        public TenantAppService(
            ITenantRepository tenantRepository,
            ITenantManager tenantManager,
            IDataSeeder dataSeeder)
        {
            DataSeeder = dataSeeder;
            TenantRepository = tenantRepository;
            TenantManager = tenantManager;
        }

        public virtual async Task<TenantDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Tenant, TenantDto>(
                await TenantRepository.GetAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
        {
            var count = await TenantRepository.GetCountAsync(input.Filter);
            var list = await TenantRepository.GetListAsync(
                input.Filter,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount
            );

            return new PagedResultDto<TenantDto>(
                count,
                ObjectMapper.Map<List<Tenant>, List<TenantDto>>(list)
            );
        }

        [Authorize(TenantManagementPermissions.Tenants.Create)]
        public virtual async Task<TenantDto> CreateAsync(TenantCreateDto input)
        {
            var tenant = await TenantManager.CreateAsync(input.Name);
            MapToEntity(tenant, input);//映射
            await TenantRepository.InsertAsync(tenant);

            await CurrentUnitOfWork.SaveChangesAsync();

            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                //TODO: Handle database creation?

                await DataSeeder.SeedAsync(
                                new DataSeedContext(tenant.Id)
                                    .WithProperty("AdminEmail", input.AdminEmailAddress)
                                    .WithProperty("AdminPassword", input.AdminPassword)
                                );
            }

            return ObjectMapper.Map<Tenant, TenantDto>(tenant);
        }

        [Authorize(TenantManagementPermissions.Tenants.Update)]
        public virtual async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
        {
            var tenant = await TenantRepository.GetAsync(id);
            await TenantManager.ChangeNameAsync(tenant, input.Name);
            MapToEntity(tenant, input);//映射
            await TenantRepository.UpdateAsync(tenant);
            return ObjectMapper.Map<Tenant, TenantDto>(tenant);
        }

        protected virtual void MapToEntity(Tenant tenant, TenantCreateOrUpdateDtoBase input)
        {
            input.MapExtraPropertiesTo(tenant);
            tenant.SetDisplayName(input.DisplayName);
            tenant.SetIndustry(input.Industry);
            tenant.SetContact(input.Contact);
            tenant.SetPhone(input.Phone);
            tenant.SetProvince(input.Province);
            tenant.SetCity(input.City);
            tenant.SetAddress(input.Address);
            tenant.License = input.License;
            tenant.Description = input.Description;
        }

        [Authorize(TenantManagementPermissions.Tenants.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var tenant = await TenantRepository.FindAsync(id);
            if (tenant == null)
            {
                return;
            }

            await TenantRepository.DeleteAsync(tenant);
        }

        [Authorize(TenantManagementPermissions.Tenants.ManageState)]
        public virtual async Task ChangeState(Guid id, TenantState state)
        {
            var tenant = await TenantRepository.GetAsync(id);
            TenantManager.ChangeState(tenant, state);
            await TenantRepository.UpdateAsync(tenant);
        }

        [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
        public virtual async Task<string> GetDefaultConnectionStringAsync(Guid id)
        {
            var tenant = await TenantRepository.GetAsync(id);
            return tenant?.FindDefaultConnectionString();
        }

        [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
        public virtual async Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
        {
            var tenant = await TenantRepository.GetAsync(id);
            tenant.SetDefaultConnectionString(defaultConnectionString);
            await TenantRepository.UpdateAsync(tenant);
        }

        [Authorize(TenantManagementPermissions.Tenants.ManageConnectionStrings)]
        public virtual async Task DeleteDefaultConnectionStringAsync(Guid id)
        {
            var tenant = await TenantRepository.GetAsync(id);
            tenant.RemoveDefaultConnectionString();
            await TenantRepository.UpdateAsync(tenant);
        }
    }
}
