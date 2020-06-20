using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientClaimDto: EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string Type { get; set; }

        public virtual string Value { get; set; }
    }
}
