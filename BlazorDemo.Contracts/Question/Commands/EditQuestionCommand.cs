using BlazorDemo.Models.Question;
using MediatR;
using System;

namespace BlazorDemo.Contracts.Question.Commands
{
    public class EditQuestionCommand : IRequest
    {
        public Guid Id { get; set; }

        public QuestionAddEdit Question { get; set; }

        public EditQuestionCommand(Guid id, QuestionAddEdit question)
        {
            Id = id;
            Question = question;
        }
    }
}
