using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace Volo.Abp.Identity
{
    [RemoteService(Name = IdentityRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("OrganizationUnit")]
    [Route("api/identity/organization-units")]
    public class OrganizationUnitController : AbpController, IOrganizationUnitAppService
    {
        protected IOrganizationUnitAppService OrganizationUnitAppService { get; }

        public OrganizationUnitController(IOrganizationUnitAppService organizationUnitAppService)
        {
            OrganizationUnitAppService = organizationUnitAppService;
        }

        [HttpGet]
        [Route("all")]
        public virtual Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync()
        {
            return OrganizationUnitAppService.GetAllListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            return OrganizationUnitAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            return OrganizationUnitAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            return OrganizationUnitAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        public virtual Task DeleteAsync(string ids)
        {
            return OrganizationUnitAppService.DeleteAsync(ids);
        }

        [HttpPut]
        [Route("{id}/move")]
        public Task MoveAsync(Guid id, Guid? parentId)
        {
            return OrganizationUnitAppService.MoveAsync(id, parentId);
        }

        [HttpPut]
        [Route("{id}/add-roles")]
        public Task AddRolesAsync(Guid id, string roleIds)
        {
            return OrganizationUnitAppService.AddRolesAsync(id, roleIds);
        }

        [HttpDelete]
        [Route("{id}/remove-roles")]
        public Task RemoveRolesAsync(Guid id, string roleIds)
        {
            return OrganizationUnitAppService.RemoveRolesAsync(id, roleIds);
        }
    }
}
