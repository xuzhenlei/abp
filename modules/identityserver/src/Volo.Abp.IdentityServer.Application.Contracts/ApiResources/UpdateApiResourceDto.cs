using System.Collections.Generic;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class UpdateApiResourceDto
    {
        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual List<string> Claims { get; set; }

        public virtual List<ApiScopeDto> Scopes { get; set; }

        public virtual List<ApiSecretDto> Secrets { get; set; }
    }
}
