using BlazorDemo.Contracts.Question;
using BlazorDemo.Models.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public QuestionsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            var request = new GetQuestionsQuery();

            return await mediator.Send(request);
        }

        [HttpPost]
        public async Task AddQuestion(Question question)
        {
            var notification = new AddQuestionCommand(question);

            await mediator.Send(notification);
        }
    }
}
