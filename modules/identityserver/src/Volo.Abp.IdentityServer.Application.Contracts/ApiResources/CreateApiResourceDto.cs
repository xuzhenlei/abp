using System.Collections.Generic;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class CreateApiResourceDto
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual List<string> Claims { get; set; }
    }
}
