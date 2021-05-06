using BlazorDemo.Models.Question;
using MediatR;

namespace BlazorDemo.Contracts.Question.Commands
{
    public class AddQuestionCommand : IRequest
    {
        public QuestionAddEdit Question { get; }

        public AddQuestionCommand(QuestionAddEdit question)
        {
            Question = question;
        }
    }
}
