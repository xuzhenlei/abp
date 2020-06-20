using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientCorsOriginDto: EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string Origin { get; set; }
    }
}
