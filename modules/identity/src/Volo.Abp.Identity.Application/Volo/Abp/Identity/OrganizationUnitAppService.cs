using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.Identity
{
    [Authorize(IdentityPermissions.OrganizationUnit.Default)]
    public class OrganizationUnitAppService : IdentityAppServiceBase, IOrganizationUnitAppService
    {
        protected OrganizationUnitManager OrganizationUnitManager { get; }

        protected IOrganizationUnitRepository OrganizationUnitRepository { get; }

        public OrganizationUnitAppService(
            OrganizationUnitManager organizationUnitManager,
            IOrganizationUnitRepository organizationUnitRepository)
        {
            OrganizationUnitManager = organizationUnitManager;
            OrganizationUnitRepository = organizationUnitRepository;
        }

        public virtual async Task<ListResultDto<OrganizationUnitDto>> GetAllListAsync()
        {
            var list = await OrganizationUnitRepository.GetListAsync();
            return new ListResultDto<OrganizationUnitDto>(
                ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitDto>>(list)
            );
        }

        public virtual async Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(
                await OrganizationUnitRepository.GetAsync(id)
            );
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Create)]
        public virtual async Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateDto input)
        {
            var organizationUnit = new OrganizationUnit(
                GuidGenerator.Create(),
                input.DisplayName,
                input.ParentId,
                CurrentTenant.Id
            );

            input.MapExtraPropertiesTo(organizationUnit);

            await OrganizationUnitManager.CreateAsync(organizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Update)]
        public virtual async Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateDto input)
        {
            var organizationUnit = await OrganizationUnitRepository.GetAsync(id);

            organizationUnit.DisplayName = input.DisplayName;
            input.MapExtraPropertiesTo(organizationUnit);
            await OrganizationUnitManager.UpdateAsync(organizationUnit);

            await OrganizationUnitManager.MoveAsync(organizationUnit.Id, input.ParentId);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Delete)]
        public virtual async Task DeleteAsync(string ids)
        {
            if (ids.IsNullOrWhiteSpace()) return;
            var idList = ids.Split(',').Select(id => Guid.Parse(id));
            foreach (var id in idList)
            {
                var organizationUnit = await OrganizationUnitRepository.FindAsync(id);
                if (organizationUnit == null)
                {
                    return;
                }
                await OrganizationUnitManager.DeleteAsync(id);
            }
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Update)]
        public virtual async Task MoveAsync(Guid id, Guid? parentId)
        {
            var organizationUnit = await OrganizationUnitRepository.FindAsync(id);
            if (organizationUnit == null)
            {
                return;
            }
            await OrganizationUnitManager.MoveAsync(organizationUnit.Id, parentId);
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Update)]
        public virtual async Task AddRolesAsync(Guid id, string roleIds)
        {
            if (roleIds.IsNullOrWhiteSpace()) return;
            var roleIdList = roleIds.Split(',').Select(id => Guid.Parse(id));
            foreach (var roleId in roleIdList)
            {
                await OrganizationUnitManager.AddRoleToOrganizationUnitAsync(roleId, id);
            }
        }

        [Authorize(IdentityPermissions.OrganizationUnit.Update)]
        public virtual async Task RemoveRolesAsync(Guid id, string roleIds)
        {
            if (roleIds.IsNullOrWhiteSpace()) return;
            var roleIdList = roleIds.Split(',').Select(id => Guid.Parse(id));
            foreach (var roleId in roleIdList)
            {
                await OrganizationUnitManager.RemoveRoleFromOrganizationUnitAsync(roleId, id);
            }
        }
    }
}
