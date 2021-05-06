using AutoMapper;
using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDemo.Services.Domain.Survey
{
    public class EditSurveyHandler : AsyncRequestHandler<EditSurveyCommand>
    {
        private readonly SurveyRepository questionRepository;
        private readonly IMapper mapper;

        public EditSurveyHandler(SurveyRepository questionRepository,
            IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        protected override async Task Handle(EditSurveyCommand request, CancellationToken cancellationToken)
        {
            var entity = await questionRepository.GetByIdAsync(request.Id);

            if (entity != null)
            {
                mapper.Map(request.Survey, entity);
                questionRepository.Update(entity);
                await questionRepository.SaveChangesAsync();
            }
        }
    }
}
