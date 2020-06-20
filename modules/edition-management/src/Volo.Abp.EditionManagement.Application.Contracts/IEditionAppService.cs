using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Volo.Abp.EditionManagement
{
    public interface IEditionAppService : ICrudAppService<EditionDto, Guid, GetEditionsInput, EditionCreateDto, EditionUpdateDto>
    {
        Task ChangeState(Guid id, EditionState state);
    }
}
