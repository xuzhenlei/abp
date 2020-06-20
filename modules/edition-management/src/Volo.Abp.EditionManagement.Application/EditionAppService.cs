using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.EditionManagement.Authorization;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.EditionManagement
{
    [Authorize(EditionManagementPermissions.Editions.Default)]
    public class EditionAppService : EditionManagementAppServiceBase, IEditionAppService
    {
        protected IEditionManager EditionManager { get; }

        protected IEditionRepository EditionRepository { get; }

        public EditionAppService(
            IEditionManager editionManager,
            IEditionRepository editionRepository)
        {
            EditionManager = editionManager;
            EditionRepository = editionRepository;
        }

        public virtual async Task<EditionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Edition, EditionDto>(
                await EditionRepository.GetAsync(id)
            );
        }

        public virtual async Task<PagedResultDto<EditionDto>> GetListAsync(GetEditionsInput input)
        {
            var count = await EditionRepository.GetCountAsync(
                input.Filter);

            var list = await EditionRepository.GetListAsync(
                input.Filter,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<EditionDto>(
                count,
                ObjectMapper.Map<List<Edition>, List<EditionDto>>(list)
            );
        }

        [Authorize(EditionManagementPermissions.Editions.Create)]
        public virtual async Task<EditionDto> CreateAsync(EditionCreateDto input)
        {
            var edition = await EditionManager.CreateAsync(input.Name);          
            MapToEntity(edition, input);//映射
            await EditionRepository.InsertAsync(edition);
            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }

        [Authorize(EditionManagementPermissions.Editions.Update)]
        public virtual async Task<EditionDto> UpdateAsync(Guid id, EditionUpdateDto input)
        {
            var edition = await EditionRepository.GetAsync(id);
            await EditionManager.ChangeNameAsync(edition, input.Name);
            MapToEntity(edition, input);//映射
            await EditionRepository.UpdateAsync(edition);
            return ObjectMapper.Map<Edition, EditionDto>(edition);
        }

        protected virtual void MapToEntity(Edition edition, EditionCreateOrUpdateDtoBase input)
        {
            input.MapExtraPropertiesTo(edition);
            EditionManager.ChangeUserCount(edition, input.UserCount);
            EditionManager.ChangeTrialDayCount(edition, input.TrialDayCount);
            EditionManager.ChangeTrialAmount(edition, input.TrialAmount);
            EditionManager.ChangeFirstAmount(edition, input.FirstAmount);
            EditionManager.ChangeMonthlyAmount(edition, input.MonthlyAmount);
            EditionManager.ChangeQuarterlyAmount(edition, input.QuarterlyAmount);
            EditionManager.ChangeYearlyAmount(edition, input.YearlyAmount);
            EditionManager.ChangePerUserAmount(edition, input.PerUserAmount);
            EditionManager.ChangeStepUserCounts(edition, input.StepUserCounts);
            edition.CoverImage = input.CoverImage;
            edition.Description = input.Description;
        }

        [Authorize(EditionManagementPermissions.Editions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            var edition = await EditionRepository.FindAsync(id);
            if (edition == null)
            {
                return;
            }
            await EditionRepository.DeleteAsync(edition);
        }

        [Authorize(EditionManagementPermissions.Editions.ManageState)]
        public virtual async Task ChangeState(Guid id, EditionState state)
        {
            var edition = await EditionRepository.FindAsync(id);
            EditionManager.ChangeState(edition, state);
            await EditionRepository.UpdateAsync(edition);
        }
    }
}
