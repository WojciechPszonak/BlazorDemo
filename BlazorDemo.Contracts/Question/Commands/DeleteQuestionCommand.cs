using MediatR;
using System;

namespace BlazorDemo.Contracts.Question.Commands
{
    public class DeleteQuestionCommand : IRequest
    {
        public Guid Id { get; }

        public DeleteQuestionCommand(Guid id)
        {
            Id = id;
        }
    }
}
