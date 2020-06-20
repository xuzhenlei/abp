using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientPropertyDto : EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string Key { get; set; }

        public virtual string Value { get; set; }
    }
}
