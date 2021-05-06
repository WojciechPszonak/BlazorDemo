using BlazorDemo.Models.Survey;
using MediatR;

namespace BlazorDemo.Contracts.Survey.Commands
{
    public class AddSurveyCommand : IRequest
    {
        public SurveyAddEdit Survey { get; }

        public AddSurveyCommand(SurveyAddEdit survey)
        {
            Survey = survey;
        }
    }
}
