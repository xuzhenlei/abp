using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    [RemoteService]
    [Route("api/identity-server/identity-resources")]
    public class IdentityResourcesController : IdentityServerControllerBase, IIdentityResourceAppService
    {
        protected IIdentityResourceAppService ResourceAppService { get; }

        public IdentityResourcesController(IIdentityResourceAppService resourceAppService)
        {
            ResourceAppService = resourceAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IdentityResourceDto> GetAsync(Guid id)
        {
            return ResourceAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<ListResultDto<IdentityResourceDto>> GetAllAsync()
        {
            return ResourceAppService.GetAllAsync();
        }

        [HttpGet]
        public Task<PagedResultDto<IdentityResourceDto>> GetListAsync(GetIdentityResourcesInput input)
        {
            return ResourceAppService.GetListAsync(input);
        }

        [HttpPost]
        [Route("create-standard-resources")]
        public Task CreateStandardAsync()
        {
            return ResourceAppService.CreateStandardAsync();
        }

        [HttpPost]
        public Task<IdentityResourceDto> CreateAsync(CreateIdentityResourceDto input)
        {
            return ResourceAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IdentityResourceDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input)
        {
            return ResourceAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return ResourceAppService.DeleteAsync(id);
        }
    }
}
