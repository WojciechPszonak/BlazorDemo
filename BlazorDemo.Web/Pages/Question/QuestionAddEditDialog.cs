using BlazorDemo.Models.Question;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorDemo.Web.Pages.Question
{
    public partial class QuestionAddEditDialog
    {
        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }
        
        [Parameter]
        public QuestionAddEdit Model { get; set; } = new QuestionAddEdit();

        void Submit() => MudDialog.Close(DialogResult.Ok(Model));
        void Cancel() => MudDialog.Cancel();
    }
}
