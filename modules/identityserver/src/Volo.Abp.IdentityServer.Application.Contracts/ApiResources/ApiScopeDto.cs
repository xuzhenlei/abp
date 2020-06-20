using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class ApiScopeDto : EntityDto
    {
        public virtual Guid ApiResourceId { get; set; }

        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Required { get; set; }

        public virtual bool Emphasize { get; set; }

        public virtual bool ShowInDiscoveryDocument { get; set; }

        public virtual List<ApiScopeClaimDto> UserClaims { get; set; }
    }
}
