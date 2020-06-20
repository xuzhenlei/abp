using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    [RemoteService]
    [Route("api/identity-server/api-resources")]
    public class ApiResourcesController : IdentityServerControllerBase, IApiResourceAppService
    {
        protected IApiResourceAppService ResourceAppService { get; }

        public ApiResourcesController(IApiResourceAppService resourceAppService)
        {
            ResourceAppService = resourceAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ApiResourceDto> GetAsync(Guid id)
        {
            return ResourceAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<ListResultDto<ApiResourceDto>> GetAllAsync()
        {
            return ResourceAppService.GetAllAsync();
        }

        [HttpGet]
        public Task<PagedResultDto<ApiResourceDto>> GetListAsync(GetApiResourcesInput input)
        {
            return ResourceAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<ApiResourceDto> CreateAsync(CreateApiResourceDto input)
        {
            return ResourceAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ApiResourceDto> UpdateAsync(Guid id, UpdateApiResourceDto input)
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
