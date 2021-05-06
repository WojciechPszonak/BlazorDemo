using BlazorDemo.Models.Question;
using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        private async Task EditQuestion(QuestionListItem item)
        {
            //var dialog = DialogService.Show<QuestionDeleteDialog>("Attention");
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    await QuestionRepository.DeleteQuestion(id);
            //    await FetchData();
            //}
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
