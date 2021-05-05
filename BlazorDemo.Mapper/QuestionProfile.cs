using AutoMapper;

namespace BlazorDemo.Mapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Entities.Question, Models.Question.Question>()
                .ReverseMap();
        }
    }
}
