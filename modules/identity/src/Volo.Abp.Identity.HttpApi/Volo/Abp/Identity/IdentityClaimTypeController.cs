using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity.ClaimTypes
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("ClaimType")]
    [Route("api/identity/claim-types")]
    public class IdentityClaimTypeController: AbpController, IIdentityClaimTypeAppService
    {
        protected IIdentityClaimTypeAppService ClaimTypeAppService { get; }

        public IdentityClaimTypeController(
            IIdentityClaimTypeAppService claimTypeAppService)
        {
            ClaimTypeAppService = claimTypeAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<IdentityClaimTypeDto> GetAsync(Guid id)
        {
            return ClaimTypeAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("all")]
        public Task<ListResultDto<IdentityClaimTypeDto>> GetAllAsync()
        {
            return ClaimTypeAppService.GetAllAsync();
        }

        [HttpGet]
        public Task<PagedResultDto<IdentityClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input)
        {
            return ClaimTypeAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<IdentityClaimTypeDto> CreateAsync(IdentityClaimTypeCreateDto input)
        {
            return ClaimTypeAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<IdentityClaimTypeDto> UpdateAsync(Guid id, IdentityClaimTypeUpdateDto input)
        {
            return ClaimTypeAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return ClaimTypeAppService.DeleteAsync(id);
        }
    }
}
