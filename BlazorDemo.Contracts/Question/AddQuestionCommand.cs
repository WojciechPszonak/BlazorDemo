using MediatR;

namespace BlazorDemo.Contracts.Question
{
    public class AddQuestionCommand : IRequest
    {
        public Models.Question.Question Question { get; set; }

        public AddQuestionCommand(Models.Question.Question question)
        {
            Question = question;
        }
    }
}
