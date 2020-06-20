using AutoMapper;

namespace Volo.Abp.EditionManagement
{
    public class EditionManagementApplicationAutoMapperProfile : Profile
    {
        public EditionManagementApplicationAutoMapperProfile()
        {
            CreateMap<Edition, EditionDto>(MemberList.None)
                .MapExtraProperties()
                .ForMember(dto => dto.StepUserCounts, opt =>
                {
                    opt.MapFrom(s => s.GetStepUserCounts());
                });
        }
    }
}