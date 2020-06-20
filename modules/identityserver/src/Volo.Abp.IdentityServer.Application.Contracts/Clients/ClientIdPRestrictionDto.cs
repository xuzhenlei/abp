using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientIdPRestrictionDto : EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string Provider { get; set; }
    }
}
