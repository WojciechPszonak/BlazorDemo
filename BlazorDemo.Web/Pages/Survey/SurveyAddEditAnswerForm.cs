using BlazorDemo.Models.Question;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyAddEditAnswerForm
    {
        [Parameter]
        public QuestionListItem Question { get; set; }
    }
}
