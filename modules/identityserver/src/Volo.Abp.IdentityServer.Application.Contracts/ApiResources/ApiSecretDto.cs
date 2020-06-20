using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class ApiSecretDto : EntityDto
    {
        public virtual Guid ApiResourceId { get; set; }

        public virtual string Type { get; set; }

        public virtual string Value { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime? Expiration { get; set; }
    }
}
