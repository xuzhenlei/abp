﻿using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class ClientDto : FullAuditedEntityDto<Guid>
    {
        public virtual string ClientId { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string Description { get; set; }

        public virtual string ClientUri { get; set; }

        public virtual string LogoUri { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string ProtocolType { get; set; }

        public virtual bool RequireClientSecret { get; set; }

        public virtual bool RequireConsent { get; set; }

        public virtual bool AllowRememberConsent { get; set; }

        public virtual bool AlwaysIncludeUserClaimsInIdToken { get; set; }

        public virtual bool RequirePkce { get; set; }

        public virtual bool AllowPlainTextPkce { get; set; }

        public virtual bool AllowAccessTokensViaBrowser { get; set; }

        public virtual string FrontChannelLogoutUri { get; set; }

        public virtual bool FrontChannelLogoutSessionRequired { get; set; }

        public virtual string BackChannelLogoutUri { get; set; }

        public virtual bool BackChannelLogoutSessionRequired { get; set; }

        public virtual bool AllowOfflineAccess { get; set; }

        public virtual int IdentityTokenLifetime { get; set; }

        public virtual int AccessTokenLifetime { get; set; }

        public virtual int AuthorizationCodeLifetime { get; set; }

        public virtual int? ConsentLifetime { get; set; }

        public virtual int AbsoluteRefreshTokenLifetime { get; set; }

        public virtual int SlidingRefreshTokenLifetime { get; set; }

        public virtual int RefreshTokenUsage { get; set; }

        public virtual bool UpdateAccessTokenClaimsOnRefresh { get; set; }

        public virtual int RefreshTokenExpiration { get; set; }

        public virtual int AccessTokenType { get; set; }

        public virtual bool EnableLocalLogin { get; set; }

        public virtual bool IncludeJwtId { get; set; }

        public virtual bool AlwaysSendClientClaims { get; set; }

        public virtual string ClientClaimsPrefix { get; set; }

        public virtual string PairWiseSubjectSalt { get; set; }

        public virtual int? UserSsoLifetime { get; set; }

        public virtual string UserCodeType { get; set; }

        public virtual int DeviceCodeLifetime { get; set; }

        public virtual List<ClientScopeDto> AllowedScopes { get; set; }

        public virtual List<ClientSecretDto> ClientSecrets { get; set; }

        public virtual List<ClientGrantTypeDto> AllowedGrantTypes { get; set; }

        public virtual List<ClientCorsOriginDto> AllowedCorsOrigins { get; set; }

        public virtual List<ClientRedirectUriDto> RedirectUris { get; set; }

        public virtual List<ClientPostLogoutRedirectUriDto> PostLogoutRedirectUris { get; set; }

        public virtual List<ClientIdPRestrictionDto> IdentityProviderRestrictions { get; set; }

        public virtual List<ClientClaimDto> Claims { get; set; }

        public virtual List<ClientPropertyDto> Properties { get; set; }
    }
}
