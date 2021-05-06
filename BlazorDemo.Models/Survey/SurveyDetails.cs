using System.Collections.Generic;

namespace BlazorDemo.Models.Survey
{
    public class SurveyDetails
    {
        public Guid Id { get; set; }

        public SurveyDetailsBasicInfo BasicInfo { get; set; }

        public SurveyDetailsContactInfo ContactInfo { get; set; }

        public IEnumerable<SurveyDetailsAnswer> Answers { get; set; } = new List<SurveyDetailsAnswer>();
    }
}
