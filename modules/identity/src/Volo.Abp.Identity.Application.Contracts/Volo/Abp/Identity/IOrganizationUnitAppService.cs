using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.Identity
{
    public interface IOrganizationUnitAppService : IApplicationService
    {
        Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync();

        Task<OrganizationUnitDto> GetAsync(Guid id);

        Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input);

        Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input);

        Task DeleteAsync(string ids);

        Task MoveAsync(Guid id, Guid? parentId);

        Task AddRolesAsync(Guid id, string roleIds);

        Task RemoveRolesAsync(Guid id, string roleIds);
    }
}
