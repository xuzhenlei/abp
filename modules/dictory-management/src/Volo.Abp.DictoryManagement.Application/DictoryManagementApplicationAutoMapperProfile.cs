using AutoMapper;

namespace Volo.Abp.DictoryManagement
{
    public class DictoryManagementApplicationAutoMapperProfile : Profile
    {
        public DictoryManagementApplicationAutoMapperProfile()
        {
            CreateMap<Dictory, DictoryDto>(MemberList.None);
            CreateMap<DataItem, DataItemDto>(MemberList.None);
        }
    }
}