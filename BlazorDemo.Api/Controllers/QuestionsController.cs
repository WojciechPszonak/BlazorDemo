using BlazorDemo.Contracts.Question.Commands;
using BlazorDemo.Contracts.Question.Queries;
using BlazorDemo.Models.Question;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPut("{id}")]
        public async Task EditQuestion(Guid id, QuestionAddEdit question)
        {
            var command = new EditQuestionCommand(id, question);

            await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteQuestion(Guid id)
        {
            var command = new DeleteQuestionCommand(id);

            await mediator.Send(command);
        }
    }
}
