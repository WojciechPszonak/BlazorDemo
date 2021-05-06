using System;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEditAnswer
    {
        public Guid QuestionId { get; set; }

        public string Value { get; set; }
    }
}
