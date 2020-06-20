using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.IdentityResources
{
    public class GetIdentityResourcesInput : PagedAndSortedResultRequestDto
    {
        public virtual string Filter { get; set; }
    }
}
