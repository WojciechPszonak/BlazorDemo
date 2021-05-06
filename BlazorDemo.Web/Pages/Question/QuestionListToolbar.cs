using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Web.Pages.Question
{
    public partial class QuestionListToolbar
    {
        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public EventCallback OnRefresh { get; set; }
    }
}
