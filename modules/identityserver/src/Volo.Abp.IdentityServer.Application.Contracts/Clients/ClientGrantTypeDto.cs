using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientGrantTypeDto: EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string GrantType { get; set; }
    }
}
