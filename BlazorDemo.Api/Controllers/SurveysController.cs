using BlazorDemo.Contracts.Survey.Commands;
using BlazorDemo.Contracts.Survey.Queries;
using BlazorDemo.Models.Survey;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IMediator mediator;

        public SurveysController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<SurveyListItem>> GetSurveys()
        {
            var query = new GetSurveysQuery();

            return await mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<SurveyDetails> GetSurveyDetails(Guid id)
        {
            var query = new GetSurveyDetailsQuery(id);

            return await mediator.Send(query);
        }

        [HttpPost]
        public async Task AddSurvey(SurveyAddEdit survey)
        {
            var command = new AddSurveyCommand(survey);

            await mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task EditSurvey(Guid id, SurveyAddEdit survey)
        {
            var command = new EditSurveyCommand(id, survey);

            await mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task DeleteSurvey(Guid id)
        {
            var command = new DeleteSurveyCommand(id);

            await mediator.Send(command);
        }
    }
}
