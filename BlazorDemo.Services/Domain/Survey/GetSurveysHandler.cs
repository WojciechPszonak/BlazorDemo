using AutoMapper;
using BlazorDemo.Contracts.Survey.Queries;
using BlazorDemo.Models.Survey;
using BlazorDemo.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class GetSurveysHandler : IRequestHandler<GetSurveysQuery, IEnumerable<SurveyListItem>>
    {
        private readonly SurveyRepository surveyRepository;
        private readonly IMapper mapper;

        public GetSurveysHandler(SurveyRepository surveyRepository,
            IMapper mapper)
        {
            this.surveyRepository = surveyRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SurveyListItem>> Handle(GetSurveysQuery request, CancellationToken cancellationToken)
        {
            var result = await surveyRepository.GetAllAsync();

            return mapper.Map<IEnumerable<SurveyListItem>>(result);
        }
    }
}
