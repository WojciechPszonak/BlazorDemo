using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEditAnswer : IEquatable<SurveyAddEditAnswer>
    {
        [Required]
        public Guid QuestionId { get; set; }

        public string QuestionText { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        public bool Equals(SurveyAddEditAnswer other)
        {
            if (other is null)
            {
                return false;
            }

            return QuestionId == other.QuestionId;
        }
    }
}
