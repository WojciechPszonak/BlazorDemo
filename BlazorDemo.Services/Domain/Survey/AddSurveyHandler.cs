using AutoMapper;
using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class AddSurveyHandler : AsyncRequestHandler<AddSurveyCommand>
    {
        private readonly SurveyRepository surveyRepository;
        private readonly IMapper mapper;

        public AddSurveyHandler(SurveyRepository surveyRepository,
            IMapper mapper)
        {
            this.surveyRepository = surveyRepository;
            this.mapper = mapper;
        }

        protected override async Task Handle(AddSurveyCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Entities.Survey>(request.Survey);

            surveyRepository.Add(entity);
            await surveyRepository.SaveChangesAsync();
        }
    }
}
