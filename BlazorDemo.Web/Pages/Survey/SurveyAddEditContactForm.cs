using BlazorDemo.Models.Survey;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyAddEditContactForm
    {
        private SurveyAddEditContactInfo model;

        [Parameter]
        public SurveyAddEditContactInfo Model
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
        public EventCallback<SurveyAddEditContactInfo> ModelChanged { get; set; }
    }
}
