using AutoMapper;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Volo.Abp.IdentityServer
{
    public class IdentityServerApplicationAutoMapperProfile : Profile
    {
        public IdentityServerApplicationAutoMapperProfile()
        {
            CreateMap<ApiResource, ApiResourceDto>();
            CreateMap<ApiSecret, ApiSecretDto>();
            CreateMap<ApiScope, ApiScopeDto>();
            CreateMap<ApiScopeClaim, ApiScopeClaimDto>();
            CreateMap<ApiResourceClaim, ApiResourceClaimDto>();

            CreateMap<IdentityResource, IdentityResourceDto>();
            CreateMap<IdentityClaim, IdentityClaimDto>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientScope, ClientScopeDto>();
            CreateMap<ClientSecret, ClientSecretDto>();
            CreateMap<ClientGrantType, ClientGrantTypeDto>();
            CreateMap<ClientCorsOrigin, ClientCorsOriginDto>();
            CreateMap<ClientRedirectUri, ClientRedirectUriDto>();
            CreateMap<ClientPostLogoutRedirectUri, ClientPostLogoutRedirectUriDto>();
            CreateMap<ClientIdPRestriction, ClientIdPRestrictionDto>();
            CreateMap<ClientClaim, ClientClaimDto>();
            CreateMap<ClientProperty, ClientPropertyDto>();
        }
    }
}