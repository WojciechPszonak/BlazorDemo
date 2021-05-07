using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Services.Infrastructure;
using MediatR;

namespace BlazorDemo.Services.Domain.Survey
{
    public class EditSurveyHandler : RequestHandler<EditSurveyCommand>
    {
        private readonly QueueService queueService;

        public EditSurveyHandler(QueueService queueService)
        {
            this.queueService = queueService;
        }

        protected override void Handle(EditSurveyCommand request)
        {
            queueService.Send("survey.edit", request);
        }
    }
}
