using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    public class GetIdentityClaimTypesInput : PagedAndSortedResultRequestDto
    {
        public virtual string Filter { get; set; }
    }
}
