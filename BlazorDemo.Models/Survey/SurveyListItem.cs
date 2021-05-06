using System;

namespace BlazorDemo.Models.Survey
{
    public class SurveyListItem
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
