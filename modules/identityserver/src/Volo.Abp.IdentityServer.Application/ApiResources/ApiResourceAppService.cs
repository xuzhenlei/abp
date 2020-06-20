using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.Authorization;

namespace Volo.Abp.IdentityServer.ApiResources
{
    [Authorize(IdentityServerPermissions.ApiResources.Default)]
    public class ApiResourceAppService : IdentityServerAppServiceBase, IApiResourceAppService
    {
        protected IApiResourceRepository ResourceRepository { get; }

        public ApiResourceAppService(IApiResourceRepository resourceRepository)
        {
            ResourceRepository = resourceRepository;
        }

        public virtual async Task<ApiResourceDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ApiResource, ApiResourceDto>(
                await ResourceRepository.GetAsync(id)
            );
        }

        public virtual async Task<ListResultDto<ApiResourceDto>> GetAllAsync()
        {
            var list = await ResourceRepository.GetListAsync();

            return new ListResultDto<ApiResourceDto>(
                ObjectMapper.Map<List<ApiResource>, List<ApiResourceDto>>(list)
            );
        }

        public virtual async Task<PagedResultDto<ApiResourceDto>> GetListAsync(GetApiResourcesInput input)
        {
            var count = await ResourceRepository.GetCountAsync();
            var list = await ResourceRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);

            return new PagedResultDto<ApiResourceDto>(
                count,
                ObjectMapper.Map<List<ApiResource>, List<ApiResourceDto>>(list)
            );
        }

        [Authorize(IdentityServerPermissions.ApiResources.Create)]
        public virtual async Task<ApiResourceDto> CreateAsync(CreateApiResourceDto input)
        {
            await ValidateNameAsync(input.Name);

            var resource = new ApiResource
            (
                GuidGenerator.Create(),
                input.Name,
                input.DisplayName,
                input.Description
            );

            input.Claims.ForEach(c => resource.AddUserClaim(c));

            await ResourceRepository.InsertAsync(resource);

            return ObjectMapper.Map<ApiResource, ApiResourceDto>(resource);
        }

        protected virtual async Task ValidateNameAsync(string name, Guid? expectedId = null)
        {
            if (await ResourceRepository.CheckNameExistAsync(name, expectedId))
            {
                throw new UserFriendlyException($"已存在名称为 {name} 的Api资源");
            }
        }

        [Authorize(IdentityServerPermissions.ApiResources.Update)]
        public virtual async Task<ApiResourceDto> UpdateAsync(Guid id, UpdateApiResourceDto input)
        {
            var resource = await ResourceRepository.GetAsync(id);
            resource.DisplayName = input.DisplayName;
            resource.Description = input.Description;
            resource.Enabled = input.Enabled;

            resource.RemoveAllUserClaims();
            input.Claims.ForEach(c => resource.AddUserClaim(c));

            resource.RemoveAllScopes();
            await CurrentUnitOfWork.SaveChangesAsync();
            input.Scopes.ForEach(s =>
            {
                var scope = resource.AddScope(s.Name, s.DisplayName, s.Description, s.Required, s.Emphasize, s.ShowInDiscoveryDocument);
                s.UserClaims.ForEach(c => scope.AddUserClaim(c.Type));
            });

            resource.RemoveAllSecrets();
            input.Secrets.ForEach(s => resource.AddSecret(s.Value, s.Expiration, s.Type, s.Description));

            await ResourceRepository.UpdateAsync(resource);

            return ObjectMapper.Map<ApiResource, ApiResourceDto>(resource);
        }

        [Authorize(IdentityServerPermissions.ApiResources.Delete)]
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
