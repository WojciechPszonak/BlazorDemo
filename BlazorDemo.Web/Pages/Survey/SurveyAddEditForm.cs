using BlazorDemo.Models.Question;
using BlazorDemo.Models.Survey;
using BlazorDemo.Web.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Web.Pages.Survey
{
    public partial class SurveyAddEditForm
    {
        [Parameter]
        public Guid? Id { get; set; }

        [Inject]
        private IQuestionRepository QuestionRepository { get; set; }
        [Inject]
        private ISurveyRepository SurveyRepository { get; set; }

        private SurveyAddEdit model = new();
        private IEnumerable<QuestionListItem> questions = new List<QuestionListItem>();

        protected override async Task OnInitializedAsync()
        {
            questions = await QuestionRepository.GetQuestions();
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id.HasValue)
            {
                var surveyDetails = await SurveyRepository.GetSurveyDetails(Id.Value);

                model = new SurveyAddEdit
                {
                    BasicInfo = new SurveyAddEditBasicInfo
                    {
                        BirthDate = surveyDetails.BasicInfo.BirthDate,
                        FirstName = surveyDetails.BasicInfo.FirstName,
                        Gender = surveyDetails.BasicInfo.Gender,
                        LastName = surveyDetails.BasicInfo.LastName,
                        Nationality = surveyDetails.BasicInfo.Nationality
                    },
                    ContactInfo = new SurveyAddEditContactInfo
                    {
                        Email = surveyDetails.ContactInfo.Email,
                        PhoneNumber = surveyDetails.ContactInfo.PhoneNumber
                    },
                    Answers = surveyDetails.Answers.Select(answer =>
                        new SurveyAddEditAnswer
                        {
                            QuestionId = answer.QuestionId,
                            Value = answer.Value
                        })
                };
            }
            await base.OnParametersSetAsync();
        }

        private async Task Submit()
        {
            if (Id.HasValue)
            {
                await SurveyRepository.EditSurvey(Id.Value, model);
            }
            else
            {
                await SurveyRepository.AddSurvey(model);
            }
        }
    }
}
