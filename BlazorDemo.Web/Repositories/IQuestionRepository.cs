using BlazorDemo.Models.Question;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Repositories
{
    public interface IQuestionRepository
    {
        [Get("")]
        Task<IEnumerable<QuestionListItem>> GetQuestions();

        [Post("")]
        Task AddQuestion(QuestionAddEdit question);

        [Put("{id}")]
        Task EditQuestion(Guid id, QuestionAddEdit question);

        [Delete("{id}")]
        Task DeleteQuestion(Guid id);
    }
}
