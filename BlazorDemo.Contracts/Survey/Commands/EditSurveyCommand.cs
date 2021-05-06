using BlazorDemo.Models.Survey;
using MediatR;
using System;

namespace BlazorDemo.Contracts.Survey.Commands
{
    public class EditSurveyCommand : IRequest
    {
        public Guid Id { get; }
        public SurveyAddEdit Survey { get; }

        public EditSurveyCommand(Guid id, SurveyAddEdit survey)
        {
            Id = id;
            Survey = survey;
        }
    }
}
