using BlazorDemo.Models.Question;
using MediatR;
using System.Collections.Generic;

namespace BlazorDemo.Contracts.Question
{
    public class GetQuestionsQuery : IRequest<IEnumerable<Models.Question.Question>>
    {
    }
}
