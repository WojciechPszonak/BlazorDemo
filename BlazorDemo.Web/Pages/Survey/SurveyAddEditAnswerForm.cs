using BlazorDemo.Models.Survey;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyAddEditAnswerForm
    {
        private SurveyAddEditAnswer model;

        [Parameter]
        public SurveyAddEditAnswer Model
        {
            get => model;
            set
            {
                if (model == value)
                    return;
                model = value;
                ModelChanged.InvokeAsync(value);
            }
        }

        [Parameter]
        public EventCallback<SurveyAddEditAnswer> ModelChanged { get; set; }
    }
}
