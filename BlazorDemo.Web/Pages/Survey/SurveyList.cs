using BlazorDemo.Models.Survey;
using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyList
    {
        private IEnumerable<SurveyListItem> surveys;

        [Inject]
        private ISurveyRepository SurveyRepository { get; set; }
        [Inject]
        private IDialogService DialogService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await FetchData();
            await base.OnInitializedAsync();
        }

        private async Task FetchData()
        {
            surveys = null;
            surveys = await SurveyRepository.GetSurveys();
        }

        private async Task Refresh()
        {
            await FetchData();
        }

        private void AddSurvey()
        {
            NavigationManager.NavigateTo("/surveys/form");
        }

        private void EditSurvey(SurveyListItem item)
        {
            NavigationManager.NavigateTo($"/surveys/form/{item.Id}");
        }

        private async Task DeleteSurvey(Guid id)
        {
            var dialog = DialogService.Show<SurveyDeleteDialog>("Attention");
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                await SurveyRepository.DeleteSurvey(id);
                await FetchData();
            }
        }
    }
}
