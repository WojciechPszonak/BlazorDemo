using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorDemo.Web.Pages.Question
{
    public partial class QuestionDeleteDialog
    {
        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();
    }
}
