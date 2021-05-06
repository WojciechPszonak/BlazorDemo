using BlazorDemo.Models.Question;
using MediatR;
using System.Collections.Generic;

namespace BlazorDemo.Contracts.Question.Queries
{
    public class GetQuestionsQuery : IRequest<IEnumerable<QuestionListItem>>
    {
    }
}
