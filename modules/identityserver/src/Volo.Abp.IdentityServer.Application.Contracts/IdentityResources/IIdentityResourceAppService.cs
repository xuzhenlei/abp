using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public interface IIdentityResourceAppService : ICrudAppService<IdentityResourceDto, Guid, GetIdentityResourcesInput, CreateIdentityResourceDto, UpdateIdentityResourceDto>
    {
        Task<ListResultDto<IdentityResourceDto>> GetAllAsync();

        Task CreateStandardAsync();
    }
}
