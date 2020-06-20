using System.Collections.Generic;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public class UpdateIdentityResourceDto
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual bool Required { get; set; }

        public virtual bool Emphasize { get; set; }

        public virtual bool ShowInDiscoveryDocument { get; set; }

        public virtual List<string> Claims { get; set; }
    }
}
