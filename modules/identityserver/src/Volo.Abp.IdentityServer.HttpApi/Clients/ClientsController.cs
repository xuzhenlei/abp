using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    [RemoteService]
    [Route("api/identity-server/clients")]
    public class ClientsController : IdentityServerControllerBase, IClientAppService
    {
        protected IClientAppService ClientAppService { get; }

        public ClientsController(IClientAppService clientAppService)
        {
            ClientAppService = clientAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ClientDto> GetAsync(Guid id)
        {
            return ClientAppService.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<ClientDto>> GetListAsync(GetClientsInput input)
        {
            return ClientAppService.GetListAsync(input);
        }

        [HttpPost]
        public Task<ClientDto> CreateAsync(CreateClientDto input)
        {
            return ClientAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<ClientDto> UpdateAsync(Guid id, UpdateClientDto input)
        {
            return ClientAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return ClientAppService.DeleteAsync(id);
        }
    }
}
