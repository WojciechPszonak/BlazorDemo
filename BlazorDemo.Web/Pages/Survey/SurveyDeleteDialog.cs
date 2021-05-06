using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyDeleteDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}
