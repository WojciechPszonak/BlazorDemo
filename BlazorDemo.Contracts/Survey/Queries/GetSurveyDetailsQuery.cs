using BlazorDemo.Models.Survey;
using MediatR;
using System;

namespace BlazorDemo.Contracts.Survey.Queries
{
    public class GetSurveyDetailsQuery : IRequest<SurveyDetails>
    {
        public Guid Id { get; }

        public GetSurveyDetailsQuery(Guid id)
        {
            Id = id;
        }
    }
}
