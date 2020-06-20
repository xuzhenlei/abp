using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.ApiResources
{
    public class GetApiResourcesInput : PagedAndSortedResultRequestDto
    {
        public virtual string Filter { get; set; }
    }
}
