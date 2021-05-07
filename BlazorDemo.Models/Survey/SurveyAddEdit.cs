using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models.Survey
{
    public class SurveyAddEdit
    {
        [ValidateComplexType]
        public SurveyAddEditBasicInfo BasicInfo { get; set; } = new SurveyAddEditBasicInfo();

        [ValidateComplexType]
        public SurveyAddEditContactInfo ContactInfo { get; set; } = new SurveyAddEditContactInfo();

        [ValidateComplexType]
        public IEnumerable<SurveyAddEditAnswer> Answers { get; set; } = new List<SurveyAddEditAnswer>();
    }
}
