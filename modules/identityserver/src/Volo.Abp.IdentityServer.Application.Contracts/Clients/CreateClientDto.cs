using System.Collections.Generic;

namespace Volo.Abp.IdentityServer.Clients
{
    public class CreateClientDto
    {
        public virtual string ClientId { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string Description { get; set; }

        public virtual string ClientUri { get; set; }

        public virtual string LogoUri { get; set; }

        public virtual bool RequireConsent { get; set; }

        public virtual string CallbackUrl { get; set; }

        public virtual string LogoutUrl { get; set; }

        public virtual List<ClientSecretDto> Secrets { get; set; }

        public virtual List<string> Scopes { get; set; }
    }
}
