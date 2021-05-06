using AutoMapper;
using BlazorDemo.Contracts.Survey.Queries;
using BlazorDemo.Models.Survey;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class GetSurveyDetailsHandler : IRequestHandler<GetSurveyDetailsQuery, SurveyDetails>
    {
        private readonly SurveyRepository surveyRepository;
        private readonly IMapper mapper;

        public GetSurveyDetailsHandler(SurveyRepository surveyRepository,
            IMapper mapper)
        {
            this.surveyRepository = surveyRepository;
            this.mapper = mapper;
        }

        public async Task<SurveyDetails> Handle(GetSurveyDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await surveyRepository.GetSurveyByIdAsync(request.Id);

            return mapper.Map<SurveyDetails>(result);
        }
    }
}
