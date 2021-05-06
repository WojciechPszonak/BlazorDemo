using BlazorDemo.Contracts.Question.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Question
{
    public class DeleteQuestionHandler : AsyncRequestHandler<DeleteQuestionCommand>
    {
        private readonly QuestionRepository questionRepository;

        public DeleteQuestionHandler(QuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        protected async override Task Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            await questionRepository.DeleteAsync(request.Id);
            await questionRepository.SaveChangesAsync();
        }
    }
}
