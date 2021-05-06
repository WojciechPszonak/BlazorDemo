using AutoMapper;
using BlazorDemo.Models.Question;

namespace BlazorDemo.Mapper
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Entities.Question, QuestionListItem>();
            CreateMap<QuestionAddEdit, Entities.Question>();
        }
    }
}
