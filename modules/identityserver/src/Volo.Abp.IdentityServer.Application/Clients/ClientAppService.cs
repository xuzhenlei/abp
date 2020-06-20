using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.Authorization;

namespace Volo.Abp.IdentityServer.Clients
{
    [Authorize(IdentityServerPermissions.Clients.Default)]
    public class ClientAppService : IdentityServerAppServiceBase, IClientAppService
    {
        protected IClientRepository ClientRepository { get; }

        public ClientAppService(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        public virtual async Task<ClientDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Client, ClientDto>(
                await ClientRepository.GetAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<ClientDto>> GetListAsync(GetClientsInput input)
        {
            var count = await ClientRepository.GetCountAsync();
            var list = await ClientRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);

            return new PagedResultDto<ClientDto>(
                count,
                ObjectMapper.Map<List<Client>, List<ClientDto>>(list)
            );
        }

        [Authorize(IdentityServerPermissions.Clients.Create)]
        public virtual async Task<ClientDto> CreateAsync(CreateClientDto input)
        {
            await ValidateClientIdAsync(input.ClientId);

            var client = new Client(GuidGenerator.Create(), input.ClientId);
            client.ClientName = input.ClientName;
            client.Description = input.Description;
            client.ClientUri = input.ClientUri;
            client.LogoUri = input.LogoUri;
            client.RequireConsent = input.RequireConsent;
            client.AddRedirectUri(input.CallbackUrl);
            client.AddPostLogoutRedirectUri(input.LogoutUrl);

            input.Secrets.ForEach(s => client.AddSecret(s.Value, s.Expiration, s.Type, s.Description));

            input.Scopes.ForEach(s => client.AddScope(s));

            await ClientRepository.InsertAsync(client);

            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        protected virtual async Task ValidateClientIdAsync(string clientId, Guid? expectedId = null)
        {
            if (await ClientRepository.CheckClientIdExistAsync(clientId, expectedId))
            {
                throw new UserFriendlyException($"已存在Client Id为 {clientId} 的客户端");
            }
        }

        [Authorize(IdentityServerPermissions.Clients.Update)]
        public virtual async Task<ClientDto> UpdateAsync(Guid id, UpdateClientDto input)
        {
            var client = await ClientRepository.GetAsync(id);
            client.ClientName = input.ClientName;
            client.Description = input.Description;
            client.ClientUri = input.ClientUri;
            client.LogoUri = input.LogoUri;
            client.Enabled = input.Enabled;
            client.RequireConsent = input.RequireConsent;
            client.AllowOfflineAccess = input.AllowOfflineAccess;
            client.AllowRememberConsent = input.AllowRememberConsent;
            client.AccessTokenLifetime = input.AccessTokenLifetime;
            client.ConsentLifetime = input.ConsentLifetime;
            client.AccessTokenType = input.AccessTokenType;
            client.EnableLocalLogin = input.EnableLocalLogin;
            client.IncludeJwtId = input.IncludeJwtId;
            client.AlwaysSendClientClaims = input.AlwaysSendClientClaims;
            client.PairWiseSubjectSalt = input.PairWiseSubjectSalt;
            client.UserSsoLifetime = input.UserSsoLifetime;
            client.UserCodeType = input.UserCodeType;
            client.DeviceCodeLifetime = input.DeviceCodeLifetime;

            client.ClientSecrets.Clear();
            input.ClientSecrets.ForEach(s => client.AddSecret(s.Value, s.Expiration, s.Type, s.Description));

            client.Claims.Clear();
            input.Claims.ForEach(c => client.AddClaim(c.Value, c.Type));

            client.Properties.Clear();
            input.Properties.ForEach(p => client.AddProperty(p.Key, p.Value));

            client.AllowedGrantTypes.Clear();
            input.AllowedGrantTypes.ForEach(t => client.AddGrantType(t));

            client.IdentityProviderRestrictions.Clear();
            input.IdentityProviderRestrictions.ForEach(p => client.AddIdentityProviderRestriction(p));

            client.AllowedScopes.Clear();
            input.Scopes.ForEach(s => client.AddScope(s));

            client.AllowedCorsOrigins.Clear();
            input.AllowedCorsOrigins.ForEach(c => client.AddCorsOrigin(c));

            client.RedirectUris.Clear();
            input.RedirectUris.ForEach(r => client.AddRedirectUri(r));

            client.PostLogoutRedirectUris.Clear();
            input.PostLogoutRedirectUris.ForEach(l => client.AddPostLogoutRedirectUri(l));

            await ClientRepository.UpdateAsync(client);

            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        [Authorize(IdentityServerPermissions.Clients.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var client = await ClientRepository.FindAsync(id);
            if (client == null)
            {
                return;
            }
            await ClientRepository.DeleteAsync(client);
        }
    }
}
