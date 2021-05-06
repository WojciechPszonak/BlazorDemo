using BlazorDemo.Models.Question;
using MediatR;
using System;

namespace BlazorDemo.Contracts.Question.Commands
{
    public class EditQuestionCommand : IRequest
    {
        public Guid Id { get; }
        public QuestionAddEdit Question { get; }

        public EditQuestionCommand(Guid id, QuestionAddEdit question)
        {
            Id = id;
            Question = question;
        }
    }
}
