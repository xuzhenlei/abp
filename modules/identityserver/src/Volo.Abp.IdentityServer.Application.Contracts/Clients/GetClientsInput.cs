using Volo.Abp.Application.Dtos;

namespace Volo.Abp.IdentityServer.Clients
{
    public class GetClientsInput : PagedAndSortedResultRequestDto
    {
        public virtual string Filter { get; set; }
    }
}
