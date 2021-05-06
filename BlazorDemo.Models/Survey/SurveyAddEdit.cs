using System.Collections.Generic;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEdit
    {
        public SurveyAddEditBasicInfo BasicInfo { get; set; } = new SurveyAddEditBasicInfo();

        public SurveyAddEditContactInfo ContactInfo { get; set; } = new SurveyAddEditContactInfo();

        public IEnumerable<SurveyAddEditAnswer> Answers { get; set; } = new List<SurveyAddEditAnswer>();
    }
}
