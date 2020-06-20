using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    public class IdentityClaimTypeAppService : IdentityAppServiceBase, IIdentityClaimTypeAppService
    {
        protected IdenityClaimTypeManager ClaimTypeManager { get; }
        protected IIdentityClaimTypeRepository ClaimTypeRepository { get; }

        public IdentityClaimTypeAppService(
            IdenityClaimTypeManager claimTypeManager,
            IIdentityClaimTypeRepository claimTypeRepository)
        {
            ClaimTypeManager = claimTypeManager;
            ClaimTypeRepository = claimTypeRepository;
        }

        public virtual async Task<IdentityClaimTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(
                await ClaimTypeRepository.GetAsync(id)
            );
        }

        public virtual async Task<ListResultDto<IdentityClaimTypeDto>> GetAllAsync()
        {
            var list = await ClaimTypeRepository.GetListAsync();

            return new ListResultDto<IdentityClaimTypeDto>(
                ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(list)
            );
        }

        public virtual async Task<PagedResultDto<IdentityClaimTypeDto>> GetListAsync(GetIdentityClaimTypesInput input)
        {
            var count = await ClaimTypeRepository.GetCountAsync();
            var list = await ClaimTypeRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter);

            return new PagedResultDto<IdentityClaimTypeDto>(
                count,
                ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(list)
            );
        }

        public virtual async Task<IdentityClaimTypeDto> CreateAsync(IdentityClaimTypeCreateDto input)
        {
            var claimType = new IdentityClaimType
            (
                GuidGenerator.Create(),
                input.Name,
                input.Required,
                false,
                input.Regex,
                input.RegexDescription,
                input.Description,
                input.ValueType
            );

            await ClaimTypeManager.CreateAsync(claimType);

            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(claimType);
        }

        public virtual async Task<IdentityClaimTypeDto> UpdateAsync(Guid id, IdentityClaimTypeUpdateDto input)
        {
            var claimType = await ClaimTypeRepository.GetAsync(id);

            claimType.Required = input.Required;
            claimType.Regex = input.Regex;
            claimType.RegexDescription = input.RegexDescription;
            claimType.Description = input.Description;

            await ClaimTypeManager.UpdateAsync(claimType);

            return ObjectMapper.Map<IdentityClaimType, IdentityClaimTypeDto>(claimType);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var claimType = await ClaimTypeRepository.FindAsync(id);
            if (claimType == null)
            {
                return;
            }
            await ClaimTypeRepository.DeleteAsync(claimType);
        }
    }
}
