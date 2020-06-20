using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public class IdentityClaimDto : EntityDto
    {
        public virtual Guid IdentityResourceId { get; set; }

        public virtual string Type { get; set; }
    }
}
