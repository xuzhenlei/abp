using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class ApiResourceClaimDto : EntityDto
    {
        public virtual Guid ApiResourceId { get; set; }

        public virtual string Type { get; set; }
    }
}
