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
        public async Task<IEnumerable<QuestionListItem>> GetQuestions()
        {
            var query = new GetQuestionsQuery();

            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task AddQuestion(QuestionAddEdit question)
        {
            var command = new AddQuestionCommand(question);

            await mediator.Send(command);
        }
    }
}
