using System.Collections.Generic;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEdit
    {
        public SurveyAddEditBasicInfo BasicInfo { get; set; }

        public SurveyAddEditContactInfo ContactInfo { get; set; }

        public IEnumerable<SurveyAddEditAnswer> Answers { get; set; } = new List<SurveyAddEditAnswer>();
    }
}
