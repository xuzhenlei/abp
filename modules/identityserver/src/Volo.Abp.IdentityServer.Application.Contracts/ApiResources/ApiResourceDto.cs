using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class ApiResourceDto : FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual List<ApiSecretDto> Secrets { get; set; }

        public virtual List<ApiScopeDto> Scopes { get; set; }

        public virtual List<ApiResourceClaimDto> UserClaims { get; set; }

        public virtual Dictionary<string, string> Properties { get; set; }
    }
}
