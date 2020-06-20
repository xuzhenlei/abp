using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.EditionManagement
{
    [Controller]
    [Area("multi-tenancy")]
    [Route("api/multi-tenancy/editions")]
    [RemoteService(Name = EditionManagementRemoteServiceConsts.RemoteServiceName)]
    public class EditionController : EditionManagementControllerBase, IEditionAppService
    {
        protected IEditionAppService EditionAppService { get; }

        public EditionController(IEditionAppService editionAppService)
        {
            EditionAppService = editionAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<EditionDto> GetAsync(Guid id)
        {
            return EditionAppService.GetAsync(id);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            return EditionAppService.GetListAsync(input);
        }

        [HttpPost]
        public virtual Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            ValidateModel();
            return EditionAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            return EditionAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return EditionAppService.DeleteAsync(id);
        }

        [HttpPut]
        [Route("{id}/change-state")]
        public virtual Task ChangeState(Guid id, EditionState state)
        {
            return EditionAppService.ChangeState(id, state);
        }
    }
}
