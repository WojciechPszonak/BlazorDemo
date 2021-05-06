using AutoMapper;
using BlazorDemo.Contracts.Question.Queries;
using BlazorDemo.Models.Question;
using BlazorDemo.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Question
{
    public class GetQuestionsHandler : IRequestHandler<GetQuestionsQuery, IEnumerable<QuestionListItem>>
    {
        private readonly QuestionRepository questionRepository;
        private readonly IMapper mapper;

        public GetQuestionsHandler(QuestionRepository questionRepository,
            IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<QuestionListItem>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
        {
            var result = await questionRepository.GetAllAsync();

            return mapper.Map<IEnumerable<QuestionListItem>>(result);
        }
    }
}
