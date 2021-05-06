using MediatR;
using System;

namespace BlazorDemo.Contracts.Survey.Commands
{
    public class DeleteSurveyCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteSurveyCommand(Guid id)
        {
            Id = id;
        }
    }
}
