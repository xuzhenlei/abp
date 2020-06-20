using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public class IdentityResourceDto: FullAuditedEntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual bool Required { get; set; }

        public virtual bool Emphasize { get; set; }

        public virtual bool ShowInDiscoveryDocument { get; set; }

        public virtual List<IdentityClaimDto> UserClaims { get; set; }

        public virtual Dictionary<string, string> Properties { get; set; }
    }
}
