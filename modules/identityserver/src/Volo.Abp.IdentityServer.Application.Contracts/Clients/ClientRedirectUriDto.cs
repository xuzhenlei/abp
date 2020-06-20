using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientRedirectUriDto : EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string RedirectUri { get; set; }
    }
}
