using System;

namespace BlazorDemo.Entities
{
    public class Answer
    {
        public Guid SurveyId { get; set; }

        public Survey Survey { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }

        public string Value { get; set; }
    }
}
