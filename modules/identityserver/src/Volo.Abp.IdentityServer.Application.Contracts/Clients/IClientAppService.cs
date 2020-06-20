using System;
using Volo.Abp.Application.Services;

namespace Volo.Abp.IdentityServer.Clients
{
    public interface IClientAppService : ICrudAppService<ClientDto, Guid, GetClientsInput, CreateClientDto, UpdateClientDto>
    {

    }
}
