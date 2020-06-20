using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientPostLogoutRedirectUriDto : EntityDto
    {
        public virtual Guid ClientId { get; set; }

        public virtual string PostLogoutRedirectUri { get; set; }
    }
}
