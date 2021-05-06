using BlazorDemo.Models.Question;
using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Pages.Question
{
    public partial class QuestionList
    {
        private IEnumerable<QuestionListItem> questions;

        [Inject]
        private IQuestionRepository QuestionRepository { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
            await base.OnInitializedAsync();
        }

        private async Task FetchData()
        {
            questions = null;
            questions = await QuestionRepository.GetQuestions();
        }

        private async Task Refresh()
        {
            await FetchData();
        }

        private async Task AddQuestion()
        {
            var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true };
            var dialog = DialogService.Show<QuestionAddEditDialog>("Add question", options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await QuestionRepository.AddQuestion(result.Data as QuestionAddEdit);
                await FetchData();
            }
        }

        private async Task EditQuestion(QuestionListItem item)
        {
            var model = new QuestionAddEdit
            {
                Text = item.Text
            };

            var parameters = new DialogParameters { ["Model"] = model };
            var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true };
            var dialog = DialogService.Show<QuestionAddEditDialog>("Edit question", parameters, options);
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await QuestionRepository.EditQuestion(item.Id, result.Data as QuestionAddEdit);
                await FetchData();
            }
        }

        private async Task DeleteQuestion(Guid id)
        {
            var dialog = DialogService.Show<QuestionDeleteDialog>("Attention");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await QuestionRepository.DeleteQuestion(id);
                await FetchData();
            }
        }
    }
}
