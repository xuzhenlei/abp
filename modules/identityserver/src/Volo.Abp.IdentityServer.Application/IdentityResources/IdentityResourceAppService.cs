using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.Authorization;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    [Authorize(IdentityServerPermissions.IdentityResources.Default)]
    public class IdentityResourceAppService : IdentityServerAppServiceBase, IIdentityResourceAppService
    {
        protected IIdentityResourceDataSeeder ResourceDataSeeder { get; }
        protected IIdentityResourceRepository ResourceRepository { get; }

        public IdentityResourceAppService(
            IIdentityResourceDataSeeder resourceDataSeeder,
            IIdentityResourceRepository resourceRepository)
        {
            ResourceDataSeeder = resourceDataSeeder;
            ResourceRepository = resourceRepository;
        }

        public virtual async Task<IdentityResourceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(
                await ResourceRepository.GetAsync(id)
            );
        }

        public virtual async Task<ListResultDto<IdentityResourceDto>> GetAllAsync()
        {
            var list = await ResourceRepository.GetListAsync();

            return new ListResultDto<IdentityResourceDto>(
                ObjectMapper.Map<List<IdentityResource>, List<IdentityResourceDto>>(list)
            );
        }

        public virtual async Task<PagedResultDto<IdentityResourceDto>> GetListAsync(GetIdentityResourcesInput input)
        {
            var count = await ResourceRepository.GetCountAsync();
            var list = await ResourceRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);

            return new PagedResultDto<IdentityResourceDto>(
                count,
                ObjectMapper.Map<List<IdentityResource>, List<IdentityResourceDto>>(list)
            );
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Create)]
        public virtual async Task CreateStandardAsync()
        {
            await ResourceDataSeeder.CreateStandardResourcesAsync();
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Create)]
        public virtual async Task<IdentityResourceDto> CreateAsync(CreateIdentityResourceDto input)
        {
            await ValidateNameAsync(input.Name);

            var resource = new IdentityResource
            (
                GuidGenerator.Create(),
                input.Name,
                input.DisplayName,
                input.Description,
                input.Enabled,
                input.Required,
                input.Emphasize,
                input.ShowInDiscoveryDocument
            );

            input.Claims.ForEach(c => resource.AddUserClaim(c));

            await ResourceRepository.InsertAsync(resource);

            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(resource);
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Update)]
        public virtual async Task<IdentityResourceDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input)
        {
            var resource = await ResourceRepository.GetAsync(id);

            await ValidateNameAsync(input.Name, resource.Id);
            resource.Name = input.Name;
            resource.DisplayName = input.DisplayName;
            resource.Description = input.Description;
            resource.Enabled = input.Enabled;
            resource.Required = input.Required;
            resource.Emphasize = input.Emphasize;
            resource.ShowInDiscoveryDocument = input.ShowInDiscoveryDocument;

            resource.RemoveAllUserClaims();
            input.Claims.ForEach(c => resource.AddUserClaim(c));

            await ResourceRepository.UpdateAsync(resource);

            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(resource);
        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            if (await ResourceRepository.CheckNameExistAsync(name, expectedId))
            {
                throw new UserFriendlyException($"已存在名称为 {name} 的ID资源");
            }
        }

        [Authorize(IdentityServerPermissions.IdentityResources.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var resource = await ResourceRepository.FindAsync(id);
            if (resource == null)
            {
                return;
            }
            await ResourceRepository.DeleteAsync(resource);
        }
    }
}
