using BlazorDemo.Models.Survey;
using MediatR;
using System.Collections.Generic;

namespace BlazorDemo.Contracts.Survey.Queries
{
    public class GetSurveysQuery : IRequest<IEnumerable<SurveyListItem>>
    {
    }
}
