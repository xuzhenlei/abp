using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService : ICrudAppService<ApiResourceDto, Guid, GetApiResourcesInput, CreateApiResourceDto, UpdateApiResourceDto>
    {
        Task<ListResultDto<ApiResourceDto>> GetAllAsync();
    }
}
