﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Volo.Abp.Identity
{
    public interface IIdentityClaimTypeAppService : ICrudAppService<IdentityClaimTypeDto, Guid, GetIdentityClaimTypesInput, IdentityClaimTypeCreateDto, IdentityClaimTypeUpdateDto>
    {
        Task<ListResultDto<IdentityClaimTypeDto>> GetAllAsync();
    }
}
