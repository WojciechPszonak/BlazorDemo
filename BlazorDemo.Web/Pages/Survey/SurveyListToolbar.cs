using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyListToolbar
    {
        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public EventCallback OnRefresh { get; set; }
    }
}
