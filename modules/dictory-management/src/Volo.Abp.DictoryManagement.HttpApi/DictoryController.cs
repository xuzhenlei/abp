using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Volo.Abp.DictoryManagement
{
    [Controller]
    [Area("basic")]
    [Route("api/basic/dictory")]
    [RemoteService(Name = DictoryManagementRemoteServiceConsts.RemoteServiceName)]
    public class DictoryController : AbpDictoryManagementControllerBase, IDictoryAppService
    {
        protected IDictoryAppService DictoryAppService { get; }

        public DictoryController(IDictoryAppService dictoryAppService)
        {
            DictoryAppService = dictoryAppService;
        }

        [HttpGet]
        [Route("{code}")]
        public Task<DictoryDto> GetAsync(string code)
        {
            return DictoryAppService.GetAsync(code);
        }

        [HttpGet]
        public Task<List<DictoryDto>> GetListAsync(Guid? parentId)
        {
            return DictoryAppService.GetListAsync(parentId);
        }

        [HttpGet]
        [Route("items/{id}")]
        public Task<DataItemDto> GetItemAsync(Guid id)
        {
            return DictoryAppService.GetItemAsync(id);
        }

        [HttpPost]
        [Route("items")]
        public Task<DataItemDto> CreateItemAsync(DataItemCreateDto input)
        {
            return DictoryAppService.CreateItemAsync(input);
        }

        [HttpPut]
        [Route("items/{id}")]
        public Task<DataItemDto> UpdateItemAsync(Guid id, DataItemUpdateDto input)
        {
            return DictoryAppService.UpdateItemAsync(id, input);
        }

        [HttpDelete]
        [Route("items")]
        public Task RemoveItemAsync(string ids)
        {
            return DictoryAppService.RemoveItemAsync(ids);
        }
    }
}
