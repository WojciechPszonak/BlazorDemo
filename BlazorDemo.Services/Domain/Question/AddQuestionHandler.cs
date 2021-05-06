using AutoMapper;
using BlazorDemo.Contracts.Question.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Question
{
    public class AddQuestionHandler : AsyncRequestHandler<AddQuestionCommand>
    {
        private readonly QuestionRepository questionRepository;
        private readonly IMapper mapper;

        public AddQuestionHandler(QuestionRepository questionRepository,
            IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        protected override async Task Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Entities.Question>(request.Question);

            questionRepository.Add(entity);
            await questionRepository.SaveChangesAsync();
        }
    }
}
