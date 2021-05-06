using BlazorDemo.Models.Survey;
using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyAddEditBasicForm
    {
        private SurveyAddEditBasicInfo model;

        [Parameter]
        public SurveyAddEditBasicInfo Model {
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
        public EventCallback<SurveyAddEditBasicInfo> ModelChanged { get; set; }
    }
}
