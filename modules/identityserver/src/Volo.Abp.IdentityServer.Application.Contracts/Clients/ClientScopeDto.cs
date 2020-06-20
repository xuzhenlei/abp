using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientScopeDto: EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string Scope { get; set; }
    }
}
