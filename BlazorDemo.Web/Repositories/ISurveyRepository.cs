using BlazorDemo.Models.Survey;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Repositories
{
    public interface ISurveyRepository
    {
        [Get("/")]
        Task<IEnumerable<SurveyListItem>> GetSurveys();

        [Get("/{id}")]
        Task<SurveyDetails> GetSurveyDetails(Guid id);

        [Post("/")]
        Task AddSurvey(SurveyAddEdit survey);

        [Put("/{id}")]
        Task EditSurvey(Guid id, SurveyAddEdit survey);

        [Delete("/{id}")]
        Task DeleteSurvey(Guid id);
    }
}
