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

        private async Task AddSurvey()
        {
            //var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true };
            //var dialog = DialogService.Show<SurveyAddEditDialog>("Add survey", options);
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    await SurveyRepository.AddSurvey(result.Data as SurveyAddEdit);
            //    await FetchData();
            //}
        }

        private async Task EditSurvey(SurveyListItem item)
        {
            //var model = new SurveyAddEdit
            //{
            //    Text = item.Text
            //};

            //var parameters = new DialogParameters { ["Model"] = model };
            //var options = new DialogOptions { MaxWidth = MaxWidth.Small, FullWidth = true };
            //var dialog = DialogService.Show<SurveyAddEditDialog>("Edit survey", parameters, options);
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    await SurveyRepository.EditSurvey(item.Id, result.Data as SurveyAddEdit);
            //    await FetchData();
            //}
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
