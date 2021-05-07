using AutoMapper;
using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class EditSurveyHandler : AsyncRequestHandler<EditSurveyCommand>
    {
        private readonly SurveyRepository surveyRepository;
        private readonly IMapper mapper;

        public EditSurveyHandler(SurveyRepository surveyRepository,
            IMapper mapper)
        {
            this.surveyRepository = surveyRepository;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditSurveyCommand request, CancellationToken cancellationToken)
        {
            var entity = await surveyRepository.GetSurveyByIdAsync(request.Id);

            if (entity != null)
            {
                mapper.Map(request.Survey, entity);
                surveyRepository.Update(entity);
                await surveyRepository.SaveChangesAsync();
            }
        }
    }
}
