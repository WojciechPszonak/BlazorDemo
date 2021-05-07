using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Services.Infrastructure;
using MediatR;

namespace BlazorDemo.Services.Domain.Survey
{
    public class AddSurveyHandler : RequestHandler<AddSurveyCommand>
    {
        private readonly QueueService queueService;

        public AddSurveyHandler(QueueService queueService)
        {
            this.queueService = queueService;
        }

        protected override void Handle(AddSurveyCommand request)
        {
            queueService.Send("survey.add", request);
        }
    }
}
