using System;

namespace BlazorDemo.Models.Survey
{
    public class SurveyDetailsAnswer
    {
        public Guid QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string Value { get; set; }
    }
}
