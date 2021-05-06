using AutoMapper;
using BlazorDemo.Models.Survey;

namespace BlazorDemo.Mapper
{
    public class SurveyProfile : Profile
    {
        public SurveyProfile()
        {
            CreateMap<Entities.Survey, SurveyListItem>();
            CreateMap<Entities.Survey, SurveyDetails>();
            CreateMap<Entities.Survey, SurveyDetailsBasicInfo>();
            CreateMap<Entities.Survey, SurveyDetailsContactInfo>();
            CreateMap<Entities.Answer, SurveyDetailsAnswer>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question.Text));

            CreateMap<SurveyAddEditBasicInfo, Entities.Survey>();
            CreateMap<SurveyAddEditContactInfo, Entities.Survey>();
            CreateMap<SurveyAddEditAnswer, Entities.Answer>();
        }
    }
}
