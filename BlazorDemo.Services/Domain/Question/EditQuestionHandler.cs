using AutoMapper;
using BlazorDemo.Contracts.Question.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Question
{
    public class EditQuestionHandler : AsyncRequestHandler<EditQuestionCommand>
    {
        private readonly QuestionRepository questionRepository;
        private readonly IMapper mapper;

        public EditQuestionHandler(QuestionRepository questionRepository,
            IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditQuestionCommand request, CancellationToken cancellationToken)
        {
            var entity = await questionRepository.GetByIdAsync(request.Id);

            if (entity != null)
            {
                mapper.Map(request.Question, entity);
                questionRepository.Update(entity);
            }
        }
    }
}
