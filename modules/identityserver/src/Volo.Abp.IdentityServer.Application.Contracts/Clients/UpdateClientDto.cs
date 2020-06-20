using System.Collections.Generic;

namespace Volo.Abp.IdentityServer.Clients
{
    public class UpdateClientDto
    {
        public virtual string ClientName { get; set; }

        public virtual string Description { get; set; }

        public virtual string ClientUri { get; set; }

        public virtual string LogoUri { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual bool RequireConsent { get; set; }

        public virtual bool AllowOfflineAccess { get; set; }

        public virtual bool AllowRememberConsent { get; set; }

        public virtual int AccessTokenLifetime { get; set; }

        public virtual int? ConsentLifetime { get; set; }

        public virtual int AccessTokenType { get; set; }

        public virtual bool EnableLocalLogin { get; set; }

        public virtual bool IncludeJwtId { get; set; }

        public virtual bool AlwaysSendClientClaims { get; set; }

        public virtual string PairWiseSubjectSalt { get; set; }

        public virtual int? UserSsoLifetime { get; set; }

        public virtual string UserCodeType { get; set; }

        public virtual int DeviceCodeLifetime { get; set; }

        public virtual List<ClientSecretDto> ClientSecrets { get; set; }

        public virtual List<ClientClaimDto> Claims { get; set; }

        public virtual List<ClientPropertyDto> Properties { get; set; }

        public virtual List<string> AllowedGrantTypes { get; set; }

        public virtual List<string> IdentityProviderRestrictions { get; set; }

        public virtual List<string> Scopes { get; set; }

        public virtual List<string> AllowedCorsOrigins { get; set; }

        public virtual List<string> RedirectUris { get; set; }

        public virtual List<string> PostLogoutRedirectUris { get; set; }
    }
}
