using AutoMapper;
using BlazorDemo.Models.Survey;

namespace BlazorDemo.Mapper
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<Entities.Enums.Gender, Gender>()
                .ReverseMap();
            
            CreateMap<Entities.Survey, SurveyListItem>();

            CreateMap<Entities.Survey, SurveyDetails>()
                .ForMember(dest => dest.BasicInfo, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src));
            CreateMap<Entities.Survey, SurveyDetailsBasicInfo>();
            CreateMap<Entities.Survey, SurveyDetailsContactInfo>();
            CreateMap<Entities.Answer, SurveyDetailsAnswer>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text));

            CreateMap<SurveyAddEdit, Entities.Survey>()
                .IncludeMembers(src => src.BasicInfo, src => src.ContactInfo);
            CreateMap<SurveyAddEditBasicInfo, Entities.Survey>();
            CreateMap<SurveyAddEditContactInfo, Entities.Survey>();
            CreateMap<SurveyAddEditAnswer, Entities.Answer>();
        }
    }
}
