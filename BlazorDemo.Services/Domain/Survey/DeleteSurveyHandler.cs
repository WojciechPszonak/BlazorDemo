using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class DeleteSurveyHandler : AsyncRequestHandler<DeleteSurveyCommand>
    {
        private readonly SurveyRepository surveyRepository;

        public DeleteSurveyHandler(SurveyRepository surveyRepository)
        {
            this.surveyRepository = surveyRepository;
        }

        protected async override Task Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            await surveyRepository.DeleteAsync(request.Id);
            await surveyRepository.SaveChangesAsync();
        }
    }
}
